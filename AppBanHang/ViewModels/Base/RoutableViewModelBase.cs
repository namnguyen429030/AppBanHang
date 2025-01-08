using ReactiveUI;
using System;

namespace AppBanHang.ViewModels.Base
{
    public abstract class RoutableViewModelBase : ReactiveObject, IRoutableViewModel
    {
        public string? UrlPathSegment { get; } = Guid.NewGuid().ToString().Substring(0, 5);

        public IScreen HostScreen { get; }

        protected RoutableViewModelBase(IScreen hostScreen)
        {
            HostScreen = hostScreen;
        }
    }
}
