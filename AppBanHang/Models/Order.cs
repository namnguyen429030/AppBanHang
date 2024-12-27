using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBanHang.Models
{
    public class Order
    {
        public required Customer Buyer { get; set; }
        public required Product[] Products { get; set; }
    }
}
