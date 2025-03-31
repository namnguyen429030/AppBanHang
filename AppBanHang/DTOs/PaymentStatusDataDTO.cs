using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppBanHang.DTOs
{
    public class PaymentStatusDataDTO
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("orderCode")]
        public int OrderCode { get; set; }

        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        [JsonPropertyName("amountPaid")]
        public int AmountPaid { get; set; }

        [JsonPropertyName("amountRemaining")]
        public int AmountRemaining { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("createdAt")]
        public string CreatedAt { get; set; }

        [JsonPropertyName("transactions")]
        public List<PaymentTransactionDTO> Transactions { get; set; }

        [JsonPropertyName("cancellationReason")]
        public string? CancellationReason { get; set; }

        [JsonPropertyName("canceledAt")]
        public string? CanceledAt { get; set; }
    }
}
