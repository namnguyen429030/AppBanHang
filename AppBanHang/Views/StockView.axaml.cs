using AppBanHang.Utilities;
using AppBanHang.ViewModels.Views;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Platform.Storage;
using Avalonia.ReactiveUI;
using MsBox.Avalonia;
using ReactiveUI;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;

namespace AppBanHang.Views
{

    public partial class StockView : ReactiveUserControl<StockViewModel>
    {
        public StockView()
        {
            AvaloniaXamlLoader.Load(this);
            this.WhenActivated(d =>
            {
                if (ViewModel != null)
                {
                    d(ViewModel.OpenFilePickerInteraction.RegisterHandler(
                        async openFileInteraction =>
                        {
                            string selectedFileAddress = string.Empty;
                            var topLevel = TopLevel.GetTopLevel(this);

                            if (topLevel != null)
                            {
                                var selectedFiles = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions()
                                {
                                    Title = "Select product's image",
                                    AllowMultiple = false,
                                    FileTypeFilter = new List<FilePickerFileType>() {
                                        new FilePickerFileType("Images")
                                        {
                                            Patterns = ["*.png", "*.jpg", "*.jpeg"],
                                            MimeTypes = ["image/png", "image/jpeg"]
                                        }
                                    },
                                    SuggestedFileName = "product_image"
                                });

                                if (selectedFiles.Count > 0)
                                {
                                    IStorageFile selectedFile = selectedFiles[0];
                                    using (var stream = await selectedFile.OpenReadAsync())
                                    {
                                        using (var streamReader = new BinaryReader(stream))
                                        {
                                            var fileContent = streamReader.ReadBytes((int)stream.Length);
                                            selectedFileAddress = await FileHelper.SaveFile(fileContent, "Assets", selectedFile.Name);
                                        }
                                    }
                                }
                            }
                            openFileInteraction.SetOutput(selectedFileAddress);
                        }
                    ));
                }
            });
        }
        static StockView()
        {
            OSKIntegration.Integrate();
        }
    }
}