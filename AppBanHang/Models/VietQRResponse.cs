using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AppBanHang.Models
{
    public class VietQRResponse
    {
        [JsonPropertyName("code")]
        public required string Code { get; set; }
        [JsonPropertyName("desc")]
        public required string Desc { get; set; }
        [JsonPropertyName("data")]
        public ResponseData? Data { get; set; }
        public class ResponseData
        {
            [JsonPropertyName("acpId")]
            public int AcpId { get; set; }
            [JsonPropertyName("accountName")]
            public required string AcccountName { get; set; }
            [JsonPropertyName("qrCode")]
            public required string QRCode { get; set; }
            [JsonPropertyName("qrDataURL")]
            public required string QRDataURL { get; set; }
        }
    }
}
