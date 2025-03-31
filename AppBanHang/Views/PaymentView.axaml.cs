using AppBanHang.Utilities;
using AppBanHang.ViewModels.Views;
using AppBanHang.Views.Windows;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;

namespace AppBanHang.Views
{

    public partial class PaymentView : ReactiveUserControl<PaymentViewModel>
    {
        public PaymentView()
        {
            AvaloniaXamlLoader.Load(this);
        }
        static PaymentView()
        {
            OSKIntegration.Integrate();
        }
    }
}