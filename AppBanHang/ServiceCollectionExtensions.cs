using AppBanHang.Repositories.Implementations;
using AppBanHang.Repositories.Interfaces;
using AppBanHang.Services.Implementations;
using AppBanHang.Services.Interfaces;
using AppBanHang.ViewModels.Views;
using AppBanHang.ViewModels.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ReactiveUI;

namespace AppBanHang
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRepositories(this IServiceCollection collection)
        {
            collection.TryAddSingleton<IUserRepository, UserRepository>();
            collection.TryAddSingleton<IProductRepository, ProductRepository>();
            collection.TryAddSingleton<IReceiptInfoRepository, ReceiptInfoRepository>();
            collection.TryAddSingleton<IReceiptRepository, ReceiptRepository>();
        }
        public static void AddServices(this IServiceCollection collection)
        {
            collection.TryAddSingleton<IUserService, UserService>();
            collection.TryAddSingleton<IProductService, ProductService>();
            collection.TryAddSingleton<IReceiptService, ReceiptService>();
        }

        public static void AddViewModels(this IServiceCollection collection)
        {
            collection.TryAddTransient<MainWindowViewModel>();
            collection.TryAddSingleton<PaymentWindowViewModel>();
            collection.TryAddTransient<HistoryViewModel>();
            collection.TryAddTransient<HomeViewModel>();
            collection.TryAddTransient<OrderViewModel>();
            collection.TryAddTransient<PaymentViewModel>();
            collection.TryAddTransient<StockViewModel>();
            collection.TryAddTransient<LoginViewModel>();
        }
    }
}
