using System;
using System.Collections.Generic;

namespace AppBanHang.Models.DTOs;

public partial class Order
{
    public int Id { get; set; }

    public double ReceiveDate { get; set; }

    public int OwnerId { get; set; }

    public string PaymentStatus { get; set; } = null!;

    public int IsReceived { get; set; }

    public string Note { get; set; } = null!;

    public int Value { get; set; }

    public virtual User Owner { get; set; } = null!;
}
