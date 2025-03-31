using AppBanHang.ViewModels.Windows;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;

namespace AppBanHang.Views.Windows
{
    public partial class PaymentWindow : ReactiveWindow<PaymentWindowViewModel>
    {
        public PaymentWindow()
        {
            InitializeComponent();
        }
    }
}