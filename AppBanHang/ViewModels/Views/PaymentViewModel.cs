using AppBanHang.Models;
using AppBanHang.ViewModels.Base;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Threading.Tasks;

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
            AddPaymentCommand = ReactiveCommand.CreateFromTask(AddPayment);
        }

        private async Task AddPayment()
        {

        }
    }
}
