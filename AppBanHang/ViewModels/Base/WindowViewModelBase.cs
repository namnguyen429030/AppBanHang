using ReactiveUI;

namespace AppBanHang.ViewModels
{
    public abstract class WindowViewModelBase : ReactiveObject, IScreen
    {
        public RoutingState Router{ get; }

        protected WindowViewModelBase()
        {
            Router = new();
        }
    }
}
