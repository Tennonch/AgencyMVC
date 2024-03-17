using System;
using System.Collections.Generic;

namespace AgencyDomain.Model;

public partial class Agent : Entity
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual ICollection<Property> Properties { get; set; } = new List<Property>();

    public virtual ICollection<Transaction1> Transaction1s { get; set; } = new List<Transaction1>();
}
