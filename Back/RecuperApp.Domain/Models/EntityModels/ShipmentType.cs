using System.ComponentModel.DataAnnotations;
using RecuperApp.Domain.Models.EntityModels.Base;

namespace RecuperApp.Domain.Models.EntityModels;

public class ShipmentType : BaseEntity
{
    [Key]
    public int ShipmentTypeId { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [StringLength(150)]
    public string Description { get; set; }

    //[InverseProperty("Shipmenttype")]
    //public virtual ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();
}
