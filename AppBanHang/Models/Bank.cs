using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppBanHang.Models
{
    public class Bank
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public required string Name { get; set; }

        [JsonPropertyName("code")]
        public required string Code { get; set; }

        [JsonPropertyName("bin")]
        public required string Bin { get; set; }

        [JsonPropertyName("shortName")]
        public required string ShortName { get; set; }

        [JsonPropertyName("logo")]
        public required string Logo { get; set; }

        [JsonPropertyName("transferSupported")]
        public int TransferSupported { get; set; }

        [JsonPropertyName("lookupSupported")]
        public int LookupSupported { get; set; }
    }
}
