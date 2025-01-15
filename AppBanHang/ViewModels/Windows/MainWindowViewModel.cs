using AppBanHang.Models;
using AppBanHang.ViewModels.Base;
using AppBanHang.ViewModels.Views;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using System;
using System.Reactive;

namespace AppBanHang.ViewModels.Windows
{
    public class MainWindowViewModel : WindowViewModelBase
    {
        public ReactiveCommand<Unit, IRoutableViewModel>? GoToHomeView { get; }
        public ReactiveCommand<Unit, IRoutableViewModel>? GoToHistoryView { get; }
        public ReactiveCommand<Unit, IRoutableViewModel>? GoToOrderView { get; }
        public ReactiveCommand<Unit, IRoutableViewModel>? GoToStockView { get; }
        public ReactiveCommand<Unit, IRoutableViewModel>? GoToPaymentView { get; }


        public MainWindowViewModel(IServiceProvider serviceProvider, IScreen screen) : base(screen)
        {
            IRoutableViewModel? homeViewModel = serviceProvider.GetService<HomeViewModel>();
            IRoutableViewModel? historyViewModel = serviceProvider.GetService<HistoryViewModel>();
            IRoutableViewModel? orderViewModel = serviceProvider.GetService<OrderViewModel>();
            IRoutableViewModel? stockViewModel = serviceProvider.GetService<StockViewModel>();
            IRoutableViewModel? paymentViewModel = serviceProvider.GetService<PaymentViewModel>();

            if (homeViewModel != null && historyViewModel != null && orderViewModel != null && stockViewModel != null && paymentViewModel != null)
            {
                Router.Navigate.Execute(homeViewModel);

                GoToHomeView = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(homeViewModel));

                GoToHistoryView = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(historyViewModel));

                GoToOrderView = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(orderViewModel));

                GoToStockView = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(stockViewModel));

                GoToPaymentView = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(paymentViewModel));
            }
        }
    }
}
