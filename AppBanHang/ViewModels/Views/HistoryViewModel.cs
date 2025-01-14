using AppBanHang.Models;
using AppBanHang.ViewModels.Base;
using ReactiveUI;

namespace AppBanHang.ViewModels.Views
{
    public class HistoryViewModel : RoutableViewModelBase
    {
        public HistoryViewModel(IScreen hostScreen, ShopManagementAppContext context) : base(hostScreen)
        {
        }
    }
}
