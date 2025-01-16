using AppBanHang.Models;
using AppBanHang.Utilities;
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
        public Button? AddPaymentButton { get; }
        public Button? ConfirmPaymentButton { get; }
        public Button? CancelPaymentButton { get; }
        public TouchScreenNumericInput? NumberInput { get; }
        public PaymentView()
        {
            AvaloniaXamlLoader.Load(this);
            NumberInput = this.FindControl<TouchScreenNumericInput>("numberInput");
            AddPaymentButton = this.FindControl<Button>("addPaymentBtn");
            ConfirmPaymentButton = this.FindControl<Button>("confirmPaymentBtn");
            CancelPaymentButton = this.FindControl<Button>("cancelPaymentBtn");
        }

        private void SelectProduct(object? sender, RoutedEventArgs args)
        {
            if(NumberInput != null)
            {
                NumberInput.IsEnabled = true;
            }
            ComponentsHelper.SetButtonsCondition(true, AddPaymentButton, ConfirmPaymentButton, CancelPaymentButton);
        }
    }
}