using System.ComponentModel.DataAnnotations;
using RecuperApp.Domain.Models.EntityModels.Base;

namespace RecuperApp.Domain.Models.EntityModels;

public class Role : BaseEntity
{
    [Key]
    public int RoleId { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    //[InverseProperty("Role")]
    //public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
