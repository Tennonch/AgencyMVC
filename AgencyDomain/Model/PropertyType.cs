using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgencyDomain.Model;

public partial class PropertyType : Entity
{
    public int Id { get; set; }
    [Required(ErrorMessage ="Поле не повинно бути порожнім")]
    [Display(Name="Тип власності")]
    public string? TypeName { get; set; }

    public virtual ICollection<Property> Properties { get; set; } = new List<Property>();
}
