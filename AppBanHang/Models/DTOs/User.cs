using System;
using System.Collections.Generic;

namespace AppBanHang.Models.DTOs;

public partial class User
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Alias { get; set; } = null!;

    public string? ClientKey { get; set; }

    public string? UserKey { get; set; }

    public string? ChecksumKey { get; set; }

    public virtual ICollection<BankAccount> BankAccounts { get; set; } = new List<BankAccount>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<Receipt> Receipts { get; set; } = new List<Receipt>();
}
