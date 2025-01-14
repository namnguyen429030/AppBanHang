using AppBanHang.Models;
using AppBanHang.ViewModels.Base;
using AppBanHang.ViewModels.Views;
using ReactiveUI;
using System.Reactive;

namespace AppBanHang.ViewModels.Windows
{
    public class MainWindowViewModel : WindowViewModelBase
    {
        public ReactiveCommand<Unit, IRoutableViewModel> GoToHomeView { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> GoToHistoryView { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> GoToOrderView { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> GoToStockView { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> GoToPaymentView { get; }


        public MainWindowViewModel(ShopManagementAppContext context) : base()
        {
            IRoutableViewModel homeViewModel = new HomeViewModel(this, context);
            IRoutableViewModel historyViewModel = new HistoryViewModel(this, context);
            IRoutableViewModel orderViewModel = new OrderViewModel(this, context);
            IRoutableViewModel stockViewModel = new StockViewModel(this, context);
            IRoutableViewModel paymentViewModel = new PaymentViewModel(this, context);

            Router.Navigate.Execute(homeViewModel);

            GoToHomeView = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(homeViewModel));

            GoToHistoryView = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(historyViewModel));

            GoToOrderView = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(orderViewModel));

            GoToStockView = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(stockViewModel));

            GoToPaymentView = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(paymentViewModel));
        }
    }
}
