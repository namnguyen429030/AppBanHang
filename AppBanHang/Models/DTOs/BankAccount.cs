using System;
using System.Collections.Generic;

namespace AppBanHang.Models.DTOs;

public partial class BankAccount
{
    public int Id { get; set; }

    public string? Alias { get; set; }

    public int BankId { get; set; }

    public string AccountNo { get; set; } = null!;

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
