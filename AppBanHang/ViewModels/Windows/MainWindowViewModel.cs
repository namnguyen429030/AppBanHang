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

        

        public MainWindowViewModel() : base()
        {
            IRoutableViewModel homeViewModel = new HomeViewModel(this);
            IRoutableViewModel historyViewModel = new HistoryViewModel(this);
            IRoutableViewModel orderViewModel = new OrderViewModel(this);
            IRoutableViewModel stockViewModel = new StockViewModel(this);
            IRoutableViewModel paymentViewModel = new PaymentViewModel(this);

            Router.Navigate.Execute(homeViewModel);

            GoToHomeView = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(homeViewModel));

            GoToHistoryView = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(historyViewModel));

            GoToOrderView = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(orderViewModel));

            GoToStockView = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(stockViewModel));

            GoToPaymentView = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(paymentViewModel));
        }
    }
}
