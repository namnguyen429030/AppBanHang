using AppBanHang.Models;
using AppBanHang.ViewModels.Base;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace AppBanHang.ViewModels.Views
{
    public class StockViewModel : RoutableViewModelBase
    {
        private readonly ShopManagementAppContext _context;
        private ObservableCollection<Product>? _products;
        private Product _selectedProduct;
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
        public StockViewModel(IScreen hostScreen, ShopManagementAppContext context) : base(hostScreen)
        {
            _context = context;
            Products = new(_context.Products);
        }
    }
}
