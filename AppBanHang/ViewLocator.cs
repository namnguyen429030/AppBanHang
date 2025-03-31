using AppBanHang.ViewModels.Views;
using AppBanHang.Views;
using ReactiveUI;
using System;

namespace AppBanHang
{
    public class ViewLocator : IViewLocator
    {
        public IViewFor? ResolveView<T>(T? viewModel, string? contract = null)
        {
            switch (viewModel)
            {
                case HomeViewModel:
                    return new HomeView();
                case StockViewModel:
                    return new StockView();
                case HistoryViewModel:
                    return new HistoryView();
                case OrderViewModel:
                    return new OrderView();
                case PaymentViewModel:
                    return new PaymentView();
                case LoginViewModel:
                    return new LoginView();
                case RegistrationViewModel:
                    return new RegistrationView();
                default:
                    throw new ArgumentOutOfRangeException(nameof(viewModel));
            }
        }
    }
}
