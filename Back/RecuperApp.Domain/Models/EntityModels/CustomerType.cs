using System.ComponentModel.DataAnnotations;
using RecuperApp.Domain.Models.EntityModels.Base;


namespace RecuperApp.Domain.Models.EntityModels;
public class CustomerType : BaseEntity
{
    [Key]
    public int CustomerTypeId { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [StringLength(150)]
    public string Description { get; set; }

    
    //[InverseProperty("Customertype")]
    //public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
