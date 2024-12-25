using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBanHang.Models
{
    public class AccountInfo
    {
        public string? Alias { get; set; }
        public required Bank Bank { get; set; }
        public required string AccountNo { get; set; }
    }
}
