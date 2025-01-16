using System;
using System.Collections.Generic;

namespace AppBanHang.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Receipt> Receipts { get; set; } = new List<Receipt>();
}
