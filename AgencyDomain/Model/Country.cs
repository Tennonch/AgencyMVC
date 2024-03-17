using System;
using System.Collections.Generic;

namespace AgencyDomain.Model;

public partial class Country : Entity
{
    public int Id { get; set; }

    public string? CountryName { get; set; }

    public virtual ICollection<City> Cities { get; set; } = new List<City>();
}
