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
                default:
                    throw new ArgumentOutOfRangeException(nameof(viewModel));
            }
        }
    }
}
