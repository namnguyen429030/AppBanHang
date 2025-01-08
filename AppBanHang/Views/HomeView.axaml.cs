using AppBanHang.ViewModels.Views;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;

namespace AppBanHang.Views
{

    public partial class HomeView : ReactiveUserControl<HomeViewModel>
    {
        public HomeView()
        {

            this.WhenActivated(dispose => { });
            AvaloniaXamlLoader.Load(this);
        }
    }
}