using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RecuperApp.Domain.Models.EntityModels.Base;

namespace RecuperApp.Domain.Models.EntityModels;
public class Customer : BaseEntity
{
    public int CustomerTypeId { get; set; }
    public virtual CustomerType CustomerType { get; set; }

    [Required]
    [StringLength(50)]
    public string Nit { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [Required]
    [StringLength(50)]
    public string LastName { get; set; }

    [StringLength(50)]
    public string Address { get; set; }

    [StringLength(20)]
    public string Cell { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime? ClientSince { get; set; }

    public bool? NeedsPickup { get; set; }


    //[InverseProperty("Customer")]
    //public virtual ICollection<Productprice> Productprices { get; set; } = new List<Productprice>();

    //[InverseProperty("Customer")]
    //public virtual ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();
}
