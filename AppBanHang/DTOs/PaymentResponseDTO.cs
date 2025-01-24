using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppBanHang.DTOs
{
    public class PaymentResponseDTO
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("desc")]
        public string Description { get; set; }

        [JsonPropertyName("data")]
        public PaymentDataDTO Data { get; set; }

        [JsonPropertyName("signature")]
        public string Signature { get; set; }
    }
}
