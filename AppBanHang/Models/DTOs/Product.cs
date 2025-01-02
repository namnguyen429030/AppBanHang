using System;
using System.Collections.Generic;

namespace AppBanHang.Models.DTOs;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Price { get; set; }

    public string? ImageAddress { get; set; }

    public int OwnerId { get; set; }

    public int Instock { get; set; }

    public virtual User Owner { get; set; } = null!;
}
