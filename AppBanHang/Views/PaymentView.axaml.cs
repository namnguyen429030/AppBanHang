using AppBanHang.Utilities;
using AppBanHang.ViewModels.Views;
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
    }
}