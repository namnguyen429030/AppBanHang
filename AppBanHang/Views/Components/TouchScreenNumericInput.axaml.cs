using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;
using System.Diagnostics;

namespace AppBanHang.Views.Components
{
    public partial class TouchScreenNumericInput : UserControl
    {
        public Popup? NumpadPopup { get; }
        public TouchScreenNumericInput()
        {
            AvaloniaXamlLoader.Load(this);
            NumpadPopup = this.FindControl<Popup>("numpadPopup");
        }

        private void ShowNumpad(object sender, GotFocusEventArgs args)
        {
            var textBox = sender as TextBox;
            if (textBox != null && NumpadPopup != null)
            {
                NumpadPopup.IsOpen = true;
            }
        }
        
        private void HideNumpad(object? sender, RoutedEventArgs args)
        {
            Debug.WriteLine($"Lost focus to: {sender}");
            Debug.WriteLine($"Focus moving from: {args.Source}");
            Debug.WriteLine($"IsPointerOverPopup: {NumpadPopup?.IsPointerOverPopup}");
            if (NumpadPopup != null && !NumpadPopup.IsPointerOverPopup)
            {
                NumpadPopup.IsOpen = false;
            }
        }
    }
}