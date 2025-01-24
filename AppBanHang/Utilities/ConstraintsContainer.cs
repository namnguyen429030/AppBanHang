using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBanHang.Utilities
{
    public static class ConstraintsContainer
    {
        public const string PAYMENT_API_DOMAIN = "https://api-merchant.payos.vn";
        public const string PAYMENT_REQUEST_URL = "/v2/payment-requests";

        public const double QRCODE_TRANSACTION_DURATION = 3;
        public const string PAYMENT_PREFIX = "GCBNQR";
        public const string CANCEL_URL = "https://your-cancel-url.com/";
        public const string RETURN_URL = "https://your-success-url.com/";
    }
}
