using AppBanHang.Models;
using AppBanHang.ViewModels;
using AppBanHang.ViewModels.Windows;
using AppBanHang.Views.Windows;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Platform.Storage;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using Splat;
using System.Reflection;

namespace AppBanHang
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
            Locator.CurrentMutable.RegisterViewsForViewModels(Assembly.GetCallingAssembly());
        }

        public override void OnFrameworkInitializationCompleted()
        {
            var services = new ServiceCollection();
            services.AddDbContext<ShopManagementAppContext>();
            services.AddSingleton<IScreen, ScreenService>();
            services.AddViewModels();
            services.AddRepositories();
            services.AddServices();

            var serviceProvider = services.BuildServiceProvider();
            services.AddSingleton(serviceProvider);
            
            var vm = serviceProvider.GetService<MainWindowViewModel>();

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var mainWindow = new MainWindow(serviceProvider)
                {
                    DataContext = vm
                };
                desktop.MainWindow = mainWindow;
                PaymentWindow paymentWindow = new();
                paymentWindow.DataContext = serviceProvider.GetService<PaymentWindowViewModel>();
                mainWindow.Closed += (s, e) => paymentWindow.Close();
                paymentWindow.Show();
            }
            base.OnFrameworkInitializationCompleted();
        }

    }
}