using System;
using System.Collections.Generic;

namespace MasterPolSystem.Models;

public partial class Product
{
    public int IdProduct { get; set; }

    public int IdProductType { get; set; }

    public string Name { get; set; } = null!;

    public int Article { get; set; }

    public double? MinCostForPartner { get; set; }

    public virtual ProductType IdProductTypeNavigation { get; set; } = null!;

    public virtual ICollection<ProductPartner> ProductPartners { get; set; } = new List<ProductPartner>();
}
