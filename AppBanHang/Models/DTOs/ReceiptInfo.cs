using System;
using System.Collections.Generic;

namespace AppBanHang.Models.DTOs;

public partial class ReceiptInfo
{
    public int ReceiptId { get; set; }

    public int ProductId { get; set; }

    public int Amount { get; set; }

    public int? Discount { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Receipt Receipt { get; set; } = null!;
}
