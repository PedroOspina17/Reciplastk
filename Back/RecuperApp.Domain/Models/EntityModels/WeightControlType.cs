﻿using System.ComponentModel.DataAnnotations;
using RecuperApp.Domain.Models.EntityModels.Base;

namespace RecuperApp.Domain.Models.EntityModels;

public class WeightControlType : BaseEntity
{
    [Key]
    public int WeightControlTypeId { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [StringLength(50)]
    public string Description { get; set; }

    //[InverseProperty("Weightcontroltype")]
    //public virtual ICollection<Weightcontrol> Weightcontrols { get; set; } = new List<Weightcontrol>();
}
