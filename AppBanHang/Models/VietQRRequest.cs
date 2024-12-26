using System.Text.Json.Serialization;

namespace AppBanHang.Models
{
    public class VietQRRequest
    {
        [JsonPropertyName("accountNo")]
        public required string AccountNo { get; set; }
        [JsonPropertyName("accountName")]
        public string? AccountName { get; set; }
        [JsonPropertyName("acqId")]
        public int AcqId { get; set; }
        [JsonPropertyName("amount")]
        public int Amount { get; set; }
        [JsonPropertyName("addInfo")]
        public string? AddInfo { get; set; }
        [JsonPropertyName("format")]
        public string? Format { get; set; }
        [JsonPropertyName("template")]
        public string? Template { get; set; }
    }
}
