using System;
using System.Collections.Generic;

namespace AgencyDomain.Model;

public partial class Transaction1 : Entity
{
    public int Id { get; set; }

    public int? PropertyId { get; set; }

    public int? ClientId { get; set; }

    public int? AgentId { get; set; }

    public int? ContractId { get; set; }

    public DateOnly? TransactionDate { get; set; }

    public virtual Agent? Agent { get; set; }

    public virtual Client? Client { get; set; }

    public virtual Contract? Contract { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Property? Property { get; set; }
}
