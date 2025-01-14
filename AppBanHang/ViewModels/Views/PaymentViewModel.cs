using AppBanHang.Models;
using AppBanHang.ViewModels.Base;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;

namespace AppBanHang.ViewModels.Views
{
    public class PaymentViewModel : RoutableViewModelBase
    {
        private readonly ShopManagementAppContext _context;
        private ObservableCollection<Product>? _products;
        public ObservableCollection<Product>? Products
        {
            get => _products;
            set => this.RaiseAndSetIfChanged(ref _products, value);
        }
        public ReactiveCommand<Unit, Unit> AddPaymentCommand { get; }
        public PaymentViewModel(IScreen hostScreen, ShopManagementAppContext context) : base(hostScreen)
        {
            _context = context;
            Products = new(_context.Products);

            AddPaymentCommand = ReactiveCommand.Create(AddPayment);
        }

        private async void AddPayment()
        {
            var newProduct = new Product()
            {
                Name = "San pham moi",
                OwnerId = 1
            };
            Products?.Add(newProduct);
            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();
        }
    }
}
