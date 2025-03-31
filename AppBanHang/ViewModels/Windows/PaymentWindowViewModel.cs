using AppBanHang.Models;
using Avalonia.Media.Imaging;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Reactive;

namespace AppBanHang.ViewModels.Windows
{
    public class PaymentWindowViewModel : WindowViewModelBase
    {
        private ObservableCollection<ReceiptInfo> _currentReceiptInfos = new();
        private int _totalValue = 0;
        private Bitmap? _paymentQrCode;
        public ObservableCollection<ReceiptInfo> CurrentReceiptInfos
        {
            get => _currentReceiptInfos;
            set
            {
                this.RaiseAndSetIfChanged(ref _currentReceiptInfos, value);
            }
        }
        public int TotalValue
        {
            get => _totalValue;
            set => this.RaiseAndSetIfChanged(ref _totalValue, value);
        }
        public Bitmap? PaymentQRCode
        {
            get => _paymentQrCode;
            set => this.RaiseAndSetIfChanged(ref _paymentQrCode, value);
        }
        public PaymentWindowViewModel(IScreen screen) : base(screen)
        {
        }
    }
}
