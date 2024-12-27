using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBanHang.Models
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Price { get; set; }
        public string? ImageAddress { get; set; }
    }
}
