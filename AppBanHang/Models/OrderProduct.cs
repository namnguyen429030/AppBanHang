using System;
using System.Collections.Generic;

namespace AppBanHang.Models;

public partial class OrderProduct
{
    public int ProductId { get; set; }

    public int OrderId { get; set; }

    public int Amount { get; set; }

    public int? Discount { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
