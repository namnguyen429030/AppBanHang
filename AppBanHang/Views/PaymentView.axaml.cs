using AppBanHang.Models;
using AppBanHang.ViewModels.Views;
using AppBanHang.Views.Components;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;

namespace AppBanHang.Views
{

    public partial class PaymentView : ReactiveUserControl<PaymentViewModel>
    {
        private Button? _addPaymentButton;
        private Button? _confirmPaymentButton;
        private Button? _cancelPaymentButton;
        public TouchScreenNumericInput? NumberInput { get; private set; }
        public PaymentView()
        {
            AvaloniaXamlLoader.Load(this);
            NumberInput = this.FindControl<TouchScreenNumericInput>("numberInput");

            _addPaymentButton = this.FindControl<Button>("addPaymentBtn");
            _confirmPaymentButton = this.FindControl<Button>("confirmPaymentBtn");
            _cancelPaymentButton = this.FindControl<Button>("cancelPaymentBtn");
        }

        private void SelectProduct(object? sender, RoutedEventArgs args)
        {
            _addPaymentButton.IsEnabled = true;
            _confirmPaymentButton.IsEnabled = true;
            //_cancelPaymentButton.IsEnabled = true;
        }
    }
}