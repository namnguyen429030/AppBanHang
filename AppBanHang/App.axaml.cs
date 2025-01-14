using AppBanHang.Models;
using AppBanHang.ViewModels.Windows;
using AppBanHang.Views.Windows;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
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

            var serviceProvider = services.BuildServiceProvider();

            var dbContext = serviceProvider.GetRequiredService<ShopManagementAppContext>();
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow(dbContext)
                {
                    DataContext = new MainWindowViewModel(dbContext),
                };
            }
            base.OnFrameworkInitializationCompleted();
        }

    }
}