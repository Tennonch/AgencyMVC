using System;
using System.Collections.Generic;

namespace AgencyDomain.Model;

public partial class City: Entity
{
    public int Id { get; set; }

    public string? CityName { get; set; }

    public int? CountryId { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual Country? Country { get; set; }
}
