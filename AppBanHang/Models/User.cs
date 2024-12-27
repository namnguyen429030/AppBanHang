using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBanHang.Models
{
    public class User
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Alias { get; set; }
        public string? ClientID { get; set; }
        public string? APIKey { get; set; }
    }
}
