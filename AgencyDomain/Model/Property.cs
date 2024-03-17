using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgencyDomain.Model;

public partial class Property : Entity
{
    public int Id { get; set; }

    public int? PropertyTypeId { get; set; }

    public int? AgentId { get; set; }

    public int? AddressId { get; set; }

    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    [Display(Name = "Ціна")]
    public decimal? Price { get; set; }

    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    [Display(Name = "Розмір")]
    public int? Size { get; set; }

    [Display(Name = "Спальні кімнати")]
    public int? Bedrooms { get; set; }

    [Display(Name = "Санвузол")]
    public int? Bathrooms { get; set; }

    [Required(ErrorMessage = "Поле не повинно бути порожнім")]
    [Display(Name = "Статус")]
    public string? Status { get; set; }

    [Display(Name = "Адреса")]
    public virtual Address? Address { get; set; }

    [Display(Name = "Агент")]
    public virtual Agent? Agent { get; set; }

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    [Display(Name = "Тип власності")]
    public virtual PropertyType? PropertyType { get; set; }

    public virtual ICollection<Transaction1> Transaction1s { get; set; } = new List<Transaction1>();
}
