using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RecuperApp.Domain.Models.EntityModels.Base;

namespace RecuperApp.Domain.Models.EntityModels;

public class Product : BaseEntity
{
    [Key]
    public int ProductId { get; set; }

    [Required]
    [StringLength(50)]
    public string ShortName { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [Required]
    [StringLength(150)]
    public string Description { get; set; }

    [Required]
    [StringLength(10)]
    public string Code { get; set; }

    public bool IsSubtype { get; set; } = false;

    public int? ParentId { get; set; }
    public virtual Product? Parent { get; set; }


    [InverseProperty("Parent")]
    public virtual ICollection<Product> SubProducts { get; set; } = [];



    //[InverseProperty("Product")]
    //public virtual ICollection<Payrollconfig> Payrollconfigs { get; set; } = new List<Payrollconfig>();

    //[InverseProperty("Product")]
    //public virtual ICollection<Productprice> Productprices { get; set; } = new List<Productprice>();

    //[InverseProperty("Product")]
    //public virtual ICollection<Remaining> Remainings { get; set; } = new List<Remaining>();

    //[InverseProperty("Product")]
    //public virtual ICollection<Shipmentdetail> Shipmentdetails { get; set; } = new List<Shipmentdetail>();

    //[InverseProperty("Product")]
    //public virtual ICollection<Weightcontroldetail> Weightcontroldetails { get; set; } = new List<Weightcontroldetail>();
}
