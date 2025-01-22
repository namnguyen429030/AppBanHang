using AppBanHang.Models;

namespace AppBanHang.Repositories.Implementations
{
    public abstract class Repository
    {
        protected readonly ShopManagementAppContext shopManagementAppContext;
        protected Repository(ShopManagementAppContext shopManagementAppContext)
        {
            this.shopManagementAppContext = shopManagementAppContext;
        }
        public void Save()
        {
            shopManagementAppContext.SaveChanges();
        }
    }
}
