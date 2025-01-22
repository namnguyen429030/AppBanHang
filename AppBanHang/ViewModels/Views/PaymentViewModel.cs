using AppBanHang.Models;
using AppBanHang.Services.Interfaces;
using AppBanHang.ViewModels.Base;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Threading.Tasks;

namespace AppBanHang.ViewModels.Views
{
    public class PaymentViewModel : RoutableViewModelBase
    {
        private ObservableCollection<Product> _products = new();
        private ObservableCollection<ReceiptInfo> _currentReceiptInfos = new();
        private string _currentProductNumber = "0";
        private User? _currentUser;
        private ReceiptInfo? _currentReceiptInfo;
        private bool _isEditing;
        private bool _isAdding;
        private bool _isUpdating;
        private bool _isConfirmed;
        private bool _isConfirmable;

        private readonly IProductService _productService;
        private readonly IUserService _userService;
        private readonly IReceiptService _receiptService;
        private Product _selectedProduct = new();
        private Receipt _currentReceipt = new();
        public Product SelectedProduct
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
        public PaymentViewModel(IScreen hostScreen, IProductService productService, IUserService userService, IReceiptService receiptService) : base(hostScreen)
        {
            AddProductToPaymentCommand = ReactiveCommand.Create(AddProductToPayment);
            ConfirmPaymentCommand = ReactiveCommand.Create(ConfirmPayment);
            _productService = productService;
            _userService = userService;
            _receiptService = receiptService;
            
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
            if (CurrentReceiptInfo == null)
            {
                CurrentReceiptInfo = new();
            }
            CurrentReceiptInfo.ProductId = SelectedProduct.Id;
            CurrentReceiptInfo.Product = SelectedProduct;
            CurrentReceiptInfo.Amount = currentProductNumber;
            CurrentReceiptInfos.Add(CurrentReceiptInfo);
            IsConfirmable = true;
        }
        public void ConfirmPayment()
        {
            IsConfirmed = true;
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
                StateSwitch(PaymentViewState.Idle);
            }
        }
        private void OnProductListUpdated(Product product)
        {
            if (CurrentUser != null)
            {
                Products = new(_productService.GetAllProductsByUserId(CurrentUser.Id));
            }
        }
        private enum PaymentViewState
        {
            Idle,
            Adding,
            Updating,
            Confirmed,
        }
        private void StateSwitch(PaymentViewState state) 
        {
            switch (state)
            {
                case PaymentViewState.Idle:
                    IsAdding = false;
                    IsConfirmed = false;
                    IsUpdating = false;
                    IsEditing = false;
                    break;
                case PaymentViewState.Adding:
                    IsEditing = true;
                    IsAdding = true;
                    IsUpdating = false;
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
                    IsConfirmed = true;
                    break;
            }
        }
    }
}
