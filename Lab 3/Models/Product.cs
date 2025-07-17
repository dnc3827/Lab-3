﻿using System;
using System.Collections.Generic;

namespace Lab_3.Models;

public partial class Product
{
    public long ProductId { get; set; }

    public string Name { get; set; } = null!;

    public string? Category { get; set; }

    public string? Color { get; set; }

    public decimal UnitPrice { get; set; }

    public long AvailableQuantity { get; set; }

    public DateTime CreateDate { get; set; }
}
