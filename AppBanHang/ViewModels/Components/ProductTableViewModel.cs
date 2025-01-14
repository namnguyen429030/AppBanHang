using AppBanHang.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBanHang.ViewModels.Components
{
    public partial class ProductTableViewModel : ReactiveObject
    {
        public ObservableCollection<Product> Products { get; set; }
        public ProductTableViewModel()
        {

        }
    }
}
