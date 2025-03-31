using AppBanHang.Models;
using AppBanHang.Services.Interfaces;
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
        private readonly IUserService _userService;
        private readonly HomeViewModel _homeViewModel;
        private readonly HistoryViewModel _historyViewModel;
        private readonly OrderViewModel _orderViewModel;
        private readonly StockViewModel _stockViewModel;
        private readonly PaymentViewModel _paymentViewModel;
        private readonly LoginViewModel _loginViewModel;

        private bool _isLoggedIn;
        public bool IsLoggedIn
        {
            get => _isLoggedIn;
            set => this.RaiseAndSetIfChanged(ref _isLoggedIn, value);
        }

        public ReactiveCommand<Unit, IRoutableViewModel>? GoToHomeView { get; }
        public ReactiveCommand<Unit, IRoutableViewModel>? GoToHistoryView { get; }
        public ReactiveCommand<Unit, IRoutableViewModel>? GoToOrderView { get; }
        public ReactiveCommand<Unit, IRoutableViewModel>? GoToStockView { get; }
        public ReactiveCommand<Unit, IRoutableViewModel>? GoToPaymentView { get; }


        public MainWindowViewModel(HomeViewModel homeViewModel, HistoryViewModel historyViewModel, OrderViewModel orderViewModel, 
                                    StockViewModel stockViewModel, PaymentViewModel paymentViewModel, LoginViewModel loginViewModel, 
                                    IScreen screen, IUserService userService) : base(screen)
        {
            _userService = userService;
            _homeViewModel = homeViewModel;
            _historyViewModel = historyViewModel;
            _orderViewModel = orderViewModel;
            _stockViewModel = stockViewModel;
            _paymentViewModel = paymentViewModel;
            _loginViewModel = loginViewModel;

            Router.Navigate.Execute(_loginViewModel);

            GoToHomeView = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(_homeViewModel));

            GoToHistoryView = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(_historyViewModel));

            GoToOrderView = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(_orderViewModel));

            GoToStockView = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(_stockViewModel));

            GoToPaymentView = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(_paymentViewModel));

            _userService.CurrentUserChanged += OnCurrentUserChanged;
        }
        private void OnCurrentUserChanged(User user)
        {
            IsLoggedIn = user != null;
            Router.Navigate.Execute(_homeViewModel);
        }
    }
}
