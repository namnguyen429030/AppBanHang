using AppBanHang.Models;
using AppBanHang.Services.Interfaces;
using AppBanHang.ViewModels.Base;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reactive;
using System;
using System.Threading.Tasks;
using System.Reactive.Linq;
using System.Diagnostics;
using Avalonia.Media.Imaging;
using AppBanHang.Utilities;
using System.Linq;

namespace AppBanHang.ViewModels.Views
{
    public class StockViewModel : RoutableViewModelBase
    {
        private ObservableCollection<Product> _products = new();
        private Product _selectedProduct = new();
        private Bitmap? _enteredProductImage;
        private User? _currentUser;
        private string _enteredProductName = string.Empty;
        private string _enteredProductPrice = "0";
        private string _enteredProductInstock = "0";
        private string? _enteredProductImageAddress = string.Empty;
        private bool _isSaving = false;
        private bool _isEditing = false;
        private bool _isProductImageAvailable = false;
        private readonly IUserService _userService;
        private readonly IProductService _productService;

        public Interaction<Unit, string> OpenFilePickerInteraction { get; }
        public ObservableCollection<Product> Products
        {
            get => _products;
            set => this.RaiseAndSetIfChanged(ref _products, value);
        }
        public Product SelectedProduct
        {
            get => _selectedProduct;
            set {
                this.RaiseAndSetIfChanged(ref _selectedProduct, value);
                OnProductSelected(value);
            }
        }
        public Bitmap? EnteredProductImage
        {
            get => _enteredProductImage;
            set => this.RaiseAndSetIfChanged(ref _enteredProductImage, value);
        }
        public User? CurrentUser
        {
            get => _currentUser;
            set => this.RaiseAndSetIfChanged(ref _currentUser, value);
        }
        public string EnteredProductName
        {
            get => _enteredProductName;
            set => this.RaiseAndSetIfChanged(ref _enteredProductName, value);
        }
        public string EnteredProductPrice
        {
            get => _enteredProductPrice;
            set
            {
                int parsedValue;
                if (int.TryParse(value, out parsedValue))
                {
                    this.RaiseAndSetIfChanged(ref _enteredProductPrice, value);
                }
                else
                {
                    this.RaiseAndSetIfChanged(ref _enteredProductPrice, "0");
                }
            }
        }
        public string EnteredProductInstock
        {
            get => _enteredProductInstock;
            set
            {
                int parsedValue;
                if (int.TryParse(value, out parsedValue))
                {
                    this.RaiseAndSetIfChanged(ref _enteredProductInstock, value);
                }
                else
                {
                    this.RaiseAndSetIfChanged(ref _enteredProductInstock, "0");
                }
            }
        }
        public string? EnteredProductImageAddress
        {
            get => _enteredProductImageAddress;
            set 
            { 
                this.RaiseAndSetIfChanged(ref _enteredProductImageAddress, value);
                if (!string.IsNullOrEmpty(value))
                {
                    EnteredProductImage = new Bitmap(value);
                }
                else
                {
                    EnteredProductImage = null;
                }
            }
        }
        public bool IsEditing
        {
            get => _isEditing;
            set => this.RaiseAndSetIfChanged(ref _isEditing, value);
        }
        public bool IsSaving
        {
            get => _isSaving;
            set => this.RaiseAndSetIfChanged(ref _isSaving, value);
        }
        public bool IsProductImageAvailable
        {
            get => _isProductImageAvailable;
            set => this.RaiseAndSetIfChanged(ref _isProductImageAvailable, value);
        }
        public StockViewModel(IScreen hostScreen, IProductService productService, IUserService userService) : base(hostScreen)
        {
            _productService = productService;
            _userService = userService;

            this.WhenAnyValue(x => x.EnteredProductImage).Subscribe(selectedProductImage => IsProductImageAvailable = (selectedProductImage != null));
            OpenFilePickerInteraction = new Interaction<Unit, string>();

            AddProductCommand = ReactiveCommand.CreateFromTask(AddProduct);
            UpdateProductCommand = ReactiveCommand.CreateFromTask(UpdateProduct);
            DeleteProductCommand = ReactiveCommand.CreateFromTask(DeleteProduct);
            SetProductImageCommand = ReactiveCommand.CreateFromTask(SetProductImage);

            _userService.CurrentUserChanged += OnCurrentUserChanged;
            _productService.ProductUpdated += OnProductListUpdated;
            _productService.ProductDeleted += OnProductListUpdated;
            _productService.ProductAdded += OnProductListUpdated;
        }
        private async Task AddProduct()
        {
            if (_userService.CurrentUser != null)
            {
                Product newProduct = new();
                newProduct.Name = EnteredProductName;
                newProduct.Price = int.Parse(EnteredProductPrice);
                newProduct.Instock = int.Parse(EnteredProductInstock);
                newProduct.OwnerId = _userService.CurrentUser.Id;
                newProduct.ImageAddress = EnteredProductImageAddress;
                try
                {
                    StateSwitch(StockViewState.Saving);
                    Products.Add(await _productService.AddProductAsync(newProduct));
                    StateSwitch(StockViewState.Idle);
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
        }
        private async Task UpdateProduct()
        {
            SelectedProduct.Name = EnteredProductName;
            SelectedProduct.ImageAddress= EnteredProductImageAddress;
            SelectedProduct.Price = int.Parse(EnteredProductPrice);
            SelectedProduct.Instock= int.Parse(EnteredProductInstock);
            await _productService.UpdateProductAsync(SelectedProduct);
        }
        private async Task DeleteProduct()
        {
            await _productService.DeleteProductAsync(SelectedProduct.Id);
        }
        private async Task SetProductImage()
        {
            var fileAddress = await OpenFilePickerInteraction.Handle(Unit.Default);
            EnteredProductImageAddress = fileAddress;
        }
        private void OnProductSelected(Product? product)
        {
            if (product != null)
            {
                EnteredProductName = _selectedProduct.Name;
                EnteredProductInstock = _selectedProduct.Instock.ToString();
                EnteredProductPrice = _selectedProduct.Price.ToString();
                EnteredProductImageAddress = _selectedProduct.ImageAddress;
                StateSwitch(StockViewState.Editing);
            }
            else
            {
                StateSwitch(StockViewState.Idle);
            }
        }
        private void OnCurrentUserChanged(User user)
        {
            CurrentUser = user;
            if(user != null)
            {
                Products = new(_productService.GetAllProductsByUserId(user.Id));
            }
        }
        private void OnProductListUpdated(Product product)
        {
            if (CurrentUser != null)
            {
                Products = new(_productService.GetAllProductsByUserId(CurrentUser.Id));
            }
        }
        private enum StockViewState
        {
            Idle,
            Editing,
            Saving,
        }
        private void StateSwitch(StockViewState state)
        {
            switch(state)
            {
                case StockViewState.Editing:
                    IsEditing = true;
                    break;
                case StockViewState.Saving:
                    IsEditing = false;
                    IsSaving = true;
                    break;
                case StockViewState.Idle:
                    SelectedProduct = new();
                    IsSaving = false;
                    IsEditing = false;
                    break;
            }
        }
        public ReactiveCommand<Unit, Unit> AddProductCommand { get; }
        public ReactiveCommand<Unit, Unit> UpdateProductCommand { get; }
        public ReactiveCommand<Unit, Unit> DeleteProductCommand { get; }
        public ReactiveCommand<Unit, Unit> SetProductImageCommand { get; }
    }
}
