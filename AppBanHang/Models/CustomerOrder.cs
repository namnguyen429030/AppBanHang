using System;
using System.Collections.Generic;

namespace AppBanHang.Models;

public partial class CustomerOrder
{
    public int OrderId { get; set; }

    public int CustomerId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
