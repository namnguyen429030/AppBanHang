using AppBanHang.Models;
using AppBanHang.Services.Interfaces;
using AppBanHang.ViewModels.Base;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reactive;

namespace AppBanHang.ViewModels.Views
{
    public class StockViewModel : RoutableViewModelBase
    {
        private ObservableCollection<Product>? _products;
        private Product _selectedProduct;
        private readonly IProductService _productService;
        public ObservableCollection<Product>? Products
        {
            get => _products;
            set => this.RaiseAndSetIfChanged(ref _products, value);
        }
        public Product SelectedProduct
        {
            get => _selectedProduct;
            set => this.RaiseAndSetIfChanged(ref _selectedProduct, value);
        }
        public StockViewModel(IScreen hostScreen, IProductService productService) : base(hostScreen)
        {
            _productService = productService;
            Products = new ObservableCollection<Product>(_productService.GetAllProducts());
        }
        public ReactiveCommand<Unit, Unit> ChooseProductCommand;

    }
}
