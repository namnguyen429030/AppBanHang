using AppBanHang.Models;

namespace AppBanHang.Repositories.Implementations
{
    public abstract class Repository
    {
        protected readonly ShopManagementAppContext _shopManagementAppContext;
        protected Repository(ShopManagementAppContext shopManagementAppContext)
        {
            _shopManagementAppContext = shopManagementAppContext;
        }

    }
}
