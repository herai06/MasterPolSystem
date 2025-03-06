using System;
using System.Collections.Generic;

namespace MasterPolSystem.Models;

public partial class Partner
{
    public int IdPartner { get; set; }

    public int IdPartnerType { get; set; }

    public string Name { get; set; } = null!;

    public string DirectorFullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string LegalAddress { get; set; } = null!;

    public string Inn { get; set; } = null!;

    public int Rating { get; set; }

    public virtual PartnerType IdPartnerTypeNavigation { get; set; } = null!;

    public virtual ICollection<ProductPartner> ProductPartners { get; set; } = new List<ProductPartner>();
}
