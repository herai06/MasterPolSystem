using System;
using System.Collections.Generic;

namespace MasterPolSystem.Models;

public partial class ProductType
{
    public int IdProductType { get; set; }

    public string Name { get; set; } = null!;

    public double Coefficient { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
