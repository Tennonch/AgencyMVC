using System;
using System.Collections.Generic;

namespace AgencyDomain.Model;

public partial class Contract : Entity
{
    public int Id { get; set; }

    public int? PropertyId { get; set; }

    public int? ClientId { get; set; }

    public int? AgentId { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public virtual Agent? Agent { get; set; }

    public virtual Client? Client { get; set; }

    public virtual Property? Property { get; set; }

    public virtual ICollection<Transaction1> Transaction1s { get; set; } = new List<Transaction1>();
}
