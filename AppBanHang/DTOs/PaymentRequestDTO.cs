using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppBanHang.DTOs
{
    public class PaymentRequestDTO
    {
        [JsonPropertyName("orderCode")]
        public int OrderCode { get; set; }

        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("cancelUrl")]
        public string CancelUrl { get; set; }

        [JsonPropertyName("returnUrl")]
        public string ReturnUrl { get; set; }

        [JsonPropertyName("signature")]
        public string Signature { get; set; }

        // Optional fields
        [JsonPropertyName("buyerName")]
        public string? BuyerName { get; set; }

        [JsonPropertyName("buyerEmail")]
        public string? BuyerEmail { get; set; }

        [JsonPropertyName("buyerPhone")]
        public string? BuyerPhone { get; set; }

        [JsonPropertyName("buyerAddress")]
        public string? BuyerAddress { get; set; }

        [JsonPropertyName("expiredAt")]
        public int? ExpiredAt { get; set; }

        [JsonPropertyName("items")]
        public List<PaymentItemDTO>? Items { get; set; }
    }
}
