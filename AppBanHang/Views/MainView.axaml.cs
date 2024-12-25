using Avalonia.Controls;
using Avalonia.Interactivity;
using MsBox.Avalonia.Enums;
using MsBox.Avalonia;
using System.Threading.Tasks;
using AppBanHang.Models;
using System.Net.Http;

namespace AppBanHang.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }
    public async void CreateQRButton_Click(object sender, RoutedEventArgs args)
    {
        var box = MessageBoxManager
           .GetMessageBoxStandard("Alert", $"Are you sure you would like to generate QR for {txtBoxValue.Text}vnd",
               ButtonEnum.YesNo, Icon.Warning);

        var result = await box.ShowAsync();
        if(result == ButtonResult.Yes)
        {
            
        }
    }
    public async Task<VietQRResponse> RequestQRCode(VietQRRequest request)
    {
        using(HttpClient client = new())
        {
            client.DefaultRequestHeaders
        }
    }
}
