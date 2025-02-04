using System.ComponentModel.DataAnnotations;
using RecuperApp.Domain.Models.EntityModels.Base;

namespace RecuperApp.Domain.Models.EntityModels;

public class Role : BaseEntity
{

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

}
