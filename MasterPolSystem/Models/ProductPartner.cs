using System;
using System.Collections.Generic;

namespace MasterPolSystem.Models;

public partial class ProductPartner
{
    public int IdProductPartner { get; set; }

    public int IdProduct { get; set; }

    public int IdPartner { get; set; }

    public int ProductQuantity { get; set; }

    public DateTime SaleDate { get; set; }

    public virtual Partner IdPartnerNavigation { get; set; } = null!;

    public virtual Product IdProductNavigation { get; set; } = null!;
}
