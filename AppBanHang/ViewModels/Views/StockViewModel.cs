using AppBanHang.Models;
using AppBanHang.ViewModels.Base;
using ReactiveUI;
using System.Collections.ObjectModel;

namespace AppBanHang.ViewModels.Views
{
    public class StockViewModel : RoutableViewModelBase
    {
        public ObservableCollection<Product> Products { get; set; }
        public StockViewModel(IScreen hostScreen) : base(hostScreen)
        {
            Products = new()
            {
                new()
                {
                    Name = "Gio lon"
                },
                new()
                {
                    Name = "Gio bo"
                },
                new()
                {
                    Name = "Gio mo"
                },
                new()
                {
                    Name = "Banh chung"
                },
                new()
                {
                    Name = "Gio lon"
                },
                new()
                {
                    Name = "Gio bo"
                },
                new()
                {
                    Name = "Gio mo"
                },
                new()
                {
                    Name = "Banh chung"
                },
                new()
                {
                    Name = "Gio lon"
                },
                new()
                {
                    Name = "Gio bo"
                },
                new()
                {
                    Name = "Gio mo"
                },
                new()
                {
                    Name = "Banh chung"
                },
                new()
                {
                    Name = "Gio lon"
                },
                new()
                {
                    Name = "Gio bo"
                },
                new()
                {
                    Name = "Gio mo"
                },
                new()
                {
                    Name = "Banh chung"
                },
            };
        }
    }
}
