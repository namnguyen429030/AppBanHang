using AppBanHang.Models;
using AppBanHang.Services.Interfaces;
using AppBanHang.ViewModels.Base;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reactive;
using System;
using System.Threading.Tasks;

namespace AppBanHang.ViewModels.Views
{
    public class StockViewModel : RoutableViewModelBase
    {
        private ObservableCollection<Product>? _products;
        private Product _selectedProduct = new();
        private bool _isEditing = false;
        private bool _isProductImageAvailable = false;
        private readonly IUserService _userService;
        private readonly IProductService _productService;


        public ObservableCollection<Product>? Products
        {
            get => _products;
            set => this.RaiseAndSetIfChanged(ref _products, value);
        }
        public Product SelectedProduct
        {
            get => _selectedProduct;
            set {
                this.RaiseAndSetIfChanged(ref _selectedProduct, value);
                IsEditing = true;
            }
        }
        public bool IsEditing
        {
            get => _isEditing;
            set => this.RaiseAndSetIfChanged(ref _isEditing, value);
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

            this.WhenAnyValue(x => x.SelectedProduct.ImageAddress).Subscribe(imageAddress => IsProductImageAvailable = !string.IsNullOrWhiteSpace(imageAddress));

            AddProductCommand = ReactiveCommand.CreateFromTask(AddProduct);
            UpdateProductCommand = ReactiveCommand.CreateFromTask(UpdateProduct);
            DeleteProductCommand = ReactiveCommand.CreateFromTask(DeleteProduct);
        }
        private async Task AddProduct()
        {
            if (_userService.CurrentUser != null)
            {
                SelectedProduct.OwnerId = _userService.CurrentUser.Id;
                await _productService.AddProductAsync(SelectedProduct);
            }
        }
        private async Task UpdateProduct()
        {

        }
        private async Task DeleteProduct()
        {

        }
        public ReactiveCommand<Unit, Unit> AddProductCommand { get; }
        public ReactiveCommand<Unit, Unit> UpdateProductCommand { get; }
        public ReactiveCommand<Unit, Unit> DeleteProductCommand { get; }
    }
}
