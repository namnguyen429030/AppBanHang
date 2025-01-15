using ReactiveUI;

namespace AppBanHang.ViewModels
{
    public abstract class WindowViewModelBase : ReactiveObject, IScreen
    {
        public RoutingState Router{ get; }
        public IScreen _screen { get; }

        protected WindowViewModelBase(IScreen screen)
        {
            _screen = screen;
            Router = _screen.Router;
        }
    }
    public class ScreenService : IScreen
    {
        public RoutingState Router { get; } = new RoutingState();
    }
}
