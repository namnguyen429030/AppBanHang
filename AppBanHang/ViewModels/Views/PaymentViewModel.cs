using AppBanHang.DTOs;
using AppBanHang.Models;
using AppBanHang.Services.Interfaces;
using AppBanHang.Utilities;
using AppBanHang.ViewModels.Base;
using AppBanHang.ViewModels.Windows;
using Avalonia.Media.Imaging;
using QRCoder;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Security.Cryptography;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppBanHang.ViewModels.Views
{
    public class PaymentViewModel : RoutableViewModelBase
    {
        private ObservableCollection<Product> _products = new();
        private ObservableCollection<ReceiptInfo> _currentReceiptInfos = new();
        private string _currentProductNumber = "0";
        private int _totalValue = 0;
        private User? _currentUser;
        private ReceiptInfo? _currentReceiptInfo;
        private bool _isEditing;
        private bool _isAdding;
        private bool _isUpdating;
        private bool _isConfirmed;
        private bool _isConfirmable;
        private bool _isPaymentMethodSelected;
        private PaymentMethod _selectedPaymentMethod;

        private readonly IProductService _productService;
        private readonly IUserService _userService;
        private readonly IReceiptService _receiptService;
        private readonly PaymentWindowViewModel _paymentWindowViewModel;
        private Product? _selectedProduct = new();
        private Receipt _currentReceipt = new();
        public Product? SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                this.RaiseAndSetIfChanged(ref _selectedProduct, value);
                OnProductSelected(value);
            }
        }
        public Receipt CurrentReceipt
        {
            get => _currentReceipt;
            set => this.RaiseAndSetIfChanged(ref _currentReceipt, value);
        }
        public ReceiptInfo? CurrentReceiptInfo
        {
            get => _currentReceiptInfo;
            set
            {
                this.RaiseAndSetIfChanged(ref _currentReceiptInfo, value);
                if(value != null)
                {
                    CurrentProductNumber = value.Amount.ToString();
                }
                else
                {
                    CurrentProductNumber = 0.ToString();
                }
            }
        }
        public User? CurrentUser
        {
            get => _currentUser;
            set => this.RaiseAndSetIfChanged(ref _currentUser, value);
        }
        public string CurrentProductNumber
        {
            get => _currentProductNumber;
            set
            {
                int parsedValue;
                if (int.TryParse(value, out parsedValue))
                {
                    this.RaiseAndSetIfChanged(ref _currentProductNumber, value);
                }
                else
                {
                    this.RaiseAndSetIfChanged(ref _currentProductNumber, "0");
                }
            }
        }
        public PaymentMethod SelectedPaymentMethod
        {
            get => _selectedPaymentMethod;
            set
            {
                this.RaiseAndSetIfChanged(ref _selectedPaymentMethod, value);
                StateSwitch(PaymentViewState.PaymentMethodSelected);
            }
        }
        public int TotalValue
        {
            get => _totalValue;
            set => this.RaiseAndSetIfChanged(ref _totalValue, value);
        }
        public bool IsEditing
        {
            get => _isEditing;
            set => this.RaiseAndSetIfChanged(ref _isEditing, value);
        }
        public bool IsConfirmed
        {
            get => _isConfirmed;
            set => this.RaiseAndSetIfChanged(ref _isConfirmed, value);
        }
        public bool IsAdding
        {
            get => _isAdding;
            set => this.RaiseAndSetIfChanged(ref _isAdding, value);
        }
        public bool IsPaymentMethodSelected
        {
            get => _isPaymentMethodSelected;
            set => this.RaiseAndSetIfChanged(ref _isPaymentMethodSelected, value);
        }
        public bool IsUpdating
        {
            get => _isUpdating;
            set => this.RaiseAndSetIfChanged(ref _isUpdating, value);
        }
        public bool IsConfirmable
        {
            get => _isConfirmable;
            set => this.RaiseAndSetIfChanged(ref _isConfirmable, value);
        }
        public ObservableCollection<Product> Products
        {
            get => _products;
            set => this.RaiseAndSetIfChanged(ref _products, value);
        }
        public ObservableCollection<ReceiptInfo> CurrentReceiptInfos
        {
            get => _currentReceiptInfos;
            set => this.RaiseAndSetIfChanged(ref _currentReceiptInfos, value);
        }
        public ReactiveCommand<Unit, Unit> AddProductToPaymentCommand { get; }
        public ReactiveCommand<Unit, Unit> ConfirmPaymentCommand { get; }
        public ReactiveCommand<Unit, Unit> CashMethodSelectedCommand { get; }
        public ReactiveCommand<Unit, Unit> QRCodeMethodSelectedCommand { get; }
        public ReactiveCommand<Unit, Unit> CheckPaymentStatusCommand { get; }
        public PaymentViewModel(IScreen hostScreen, IProductService productService, IUserService userService, 
                                IReceiptService receiptService, PaymentWindowViewModel paymentWindowViewModel) : base(hostScreen)
        {
            AddProductToPaymentCommand = ReactiveCommand.Create(AddProductToPayment);
            ConfirmPaymentCommand = ReactiveCommand.CreateFromTask(ConfirmPayment);
            CashMethodSelectedCommand = ReactiveCommand.Create(() => { SelectedPaymentMethod = PaymentMethod.Cash; });
            QRCodeMethodSelectedCommand = ReactiveCommand.CreateFromTask(QRCodeMethodSelected);
            CheckPaymentStatusCommand = ReactiveCommand.CreateFromTask(CheckPaymentStatus);
            _productService = productService;
            _userService = userService;
            _receiptService = receiptService;
            _paymentWindowViewModel = paymentWindowViewModel;

            _userService.CurrentUserChanged += OnCurrentUserChanged;
            _productService.ProductUpdated += OnProductListUpdated;
            _productService.ProductDeleted += OnProductListUpdated;
            _productService.ProductAdded += OnProductListUpdated;

        }


        private void AddProductToPayment()
        {
            var currentProductNumber = int.Parse(CurrentProductNumber);
            if(currentProductNumber <= 0)
            {
                RemoveProductFromPayment();
                return;
            }
            if (SelectedProduct != null)
            {
                CurrentReceiptInfo = CurrentReceiptInfos.FirstOrDefault(ri => ri.ProductId == SelectedProduct.Id);
                if (CurrentReceiptInfo == null)
                {
                    CurrentReceiptInfo = new();
                    CurrentReceiptInfo.ProductId = SelectedProduct.Id;
                    CurrentReceiptInfo.Product = SelectedProduct;
                    CurrentReceiptInfo.Amount = currentProductNumber;
                    CurrentReceiptInfo.TotalValue = currentProductNumber * SelectedProduct.Price;
                    CurrentReceiptInfos.Add(CurrentReceiptInfo);
                }
                else
                {
                    CurrentReceiptInfo.Amount = currentProductNumber;
                    CurrentReceiptInfo.TotalValue = currentProductNumber * SelectedProduct.Price;
                    CurrentReceiptInfos[CurrentReceiptInfos.IndexOf(CurrentReceiptInfo)] = CurrentReceiptInfo;
                }
                _paymentWindowViewModel.CurrentReceiptInfos = CurrentReceiptInfos;
                SelectedProduct = null;
                IsConfirmable = true;
            }
        }
        public async Task ConfirmPayment()
        {
            if (_currentUser != null)
            {
                CurrentReceipt = new()
                {
                    CreatedDate = DateTime.Now.Ticks,
                    OwnerId = _currentUser.Id,
                    PaymentMethodId = 1,
                    CustomerId = 1,
                    Value = TotalValue
                };
                CurrentReceipt = await _receiptService.AddReceiptAsync(CurrentReceipt, CurrentReceiptInfos);
                StateSwitch(PaymentViewState.Confirmed);
            }
        }
        private async Task QRCodeMethodSelected()
        {
            SelectedPaymentMethod = PaymentMethod.QRCode;
            if (_currentUser != null && _currentUser.ClientKey != null && _currentUser.ApiKey != null && _currentUser.ChecksumKey != null)
            {
                List<PaymentItemDTO> items = new();
                string description = $"{ConstraintsContainer.PAYMENT_PREFIX}{CurrentReceipt.Id}";
                string data = $"amount={TotalValue}&cancelUrl={ConstraintsContainer.CANCEL_URL}&description={description}&orderCode={CurrentReceipt.Id}&returnUrl={ConstraintsContainer.RETURN_URL}";
                string signature = APIHelper.GenerateSignature(data, _currentUser.ChecksumKey);
                foreach(var receiptInfo in CurrentReceiptInfos)
                {
                    PaymentItemDTO item = new();
                    item.Name = receiptInfo.Product.Name;
                    item.Price = receiptInfo.Product.Price;
                    item.Quantity = receiptInfo.Amount;
                }
                PaymentRequestDTO paymentRequestDTO = new()
                {
                    Amount = TotalValue,
                    Description = description,
                    Items = items,
                    Signature = signature,
                    CancelUrl = ConstraintsContainer.CANCEL_URL,
                    OrderCode = CurrentReceipt.Id,
                    ReturnUrl = ConstraintsContainer.RETURN_URL,
                    ExpiredAt = TimeHelper.ToUnixTimestamp(DateTime.Now.AddMinutes(ConstraintsContainer.QRCODE_TRANSACTION_DURATION)),

                };
                var response = await APIHelper.CreatePaymentRequest($"{ConstraintsContainer.PAYMENT_API_DOMAIN}{ConstraintsContainer.PAYMENT_REQUEST_URL}", _userService.CurrentUser.ClientKey, _userService.CurrentUser.ApiKey, paymentRequestDTO);
                if (response != null)
                {
                    PaymentResponseDTO? paymentResponseDTO = JsonSerializer.Deserialize<PaymentResponseDTO>(response);
                    if (paymentResponseDTO != null)
                    {
                        var qrCodeImage = QRCodeHelper.GenerateQRImage(paymentResponseDTO.Data.QrCode);
                        if (qrCodeImage != null)
                        {
                            using (var stream = new MemoryStream(qrCodeImage))
                            {
                                Bitmap paymentQRCode = new(stream);
                                _paymentWindowViewModel.PaymentQRCode = paymentQRCode;
                            }
                        }
                    }
                }
            }
        }
        private async Task CheckPaymentStatus()
        {
            switch (SelectedPaymentMethod)
            {
                case PaymentMethod.Cash:
                    StateSwitch(PaymentViewState.Idle);
                    break;
                case PaymentMethod.QRCode:
                    break;
            }
        }
        private void RemoveProductFromPayment()
        {
            if (CurrentReceiptInfo != null)
            {
                CurrentReceiptInfos.Remove(CurrentReceiptInfo);
                if (CurrentReceiptInfos.Count <= 0)
                {
                    IsConfirmable = false;
                    StateSwitch(PaymentViewState.Idle);
                }
                _paymentWindowViewModel.CurrentReceiptInfos = CurrentReceiptInfos;
            }
        }
        private void OnCurrentUserChanged(User user)
        {
            CurrentUser = user;
            if (user != null)
            {
                Products = new(_productService.GetAllProductsByUserId(user.Id));
            }
        }
        private void OnProductSelected(Product? product)
        {
            if (product != null)
            {
                var selectedReceiptInfo = CurrentReceiptInfos.FirstOrDefault(ri => ri.ProductId == product.Id);
                CurrentReceiptInfo = selectedReceiptInfo;
                if (selectedReceiptInfo != null)
                {
                    CurrentProductNumber = selectedReceiptInfo.Amount.ToString();
                    StateSwitch(PaymentViewState.Updating);
                }
                else
                {
                    CurrentProductNumber = 0.ToString();
                    StateSwitch(PaymentViewState.Adding);
                }
            }
            else
            {
                StateSwitch(PaymentViewState.Edited);
            }
        }
        private void OnProductListUpdated(Product product)
        {
            if (CurrentUser != null)
            {
                Products = new(_productService.GetAllProductsByUserId(CurrentUser.Id));
            }
        }
        public enum PaymentViewState
        {
            Idle,
            Adding,
            Updating,
            Edited,
            Confirmed,
            PaymentMethodSelected,

        }
        public enum PaymentMethod
        {
            Cash,
            QRCode,
        }
        private void StateSwitch(PaymentViewState state) 
        {
            switch (state)
            {
                case PaymentViewState.Idle:
                    CurrentReceipt = new();
                    CurrentReceiptInfo = null;
                    CurrentReceiptInfos = new();
                    IsAdding = false;
                    IsConfirmed = false;
                    IsUpdating = false;
                    IsEditing = false;
                    IsPaymentMethodSelected = false;
                    break;
                case PaymentViewState.Adding:
                    IsEditing = true;
                    IsAdding = true;
                    IsUpdating = false;
                    break;
                case PaymentViewState.Edited:
                    IsEditing = false;
                    IsUpdating = false;
                    IsAdding = false;
                    UpdateTotalValue();
                    break;
                case PaymentViewState.Updating:
                    IsEditing = true;
                    IsAdding = false;
                    IsUpdating = true;
                    break;
                case PaymentViewState.Confirmed:
                    IsAdding = false;
                    IsEditing = false;
                    IsUpdating = false;
                    IsConfirmable = false;
                    IsConfirmed = true;
                    break;
                case PaymentViewState.PaymentMethodSelected:
                    IsPaymentMethodSelected = true;
                    break;
            }
        }
        private void UpdateTotalValue()
        {
            TotalValue = 0;
            foreach (var receiptInfo in CurrentReceiptInfos)
            {
                TotalValue += receiptInfo.TotalValue;
            }
        }
    }
}
