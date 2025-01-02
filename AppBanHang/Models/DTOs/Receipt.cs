using System;
using System.Collections.Generic;

namespace AppBanHang.Models.DTOs;

public partial class Receipt
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public double CreatedDate { get; set; }

    public int OwnerId { get; set; }

    public int PaymentMethodId { get; set; }

    public string? Note { get; set; }

    public int Value { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual User Owner { get; set; } = null!;

    public virtual PaymentMethod PaymentMethod { get; set; } = null!;
}
