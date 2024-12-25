using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppBanHang.Models
{
    public class BankResponse
    {
        [JsonPropertyName("code")]
        public required string Code { get; set; }
        [JsonPropertyName("desc")]
        public required string Desc { get; set; }
        [JsonPropertyName("data")]
        public Bank? Data { get; set; }
    }
}
