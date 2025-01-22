using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RecuperApp.Domain.Models.EntityModels.Base;

namespace RecuperApp.Domain.Models.EntityModels;

public class Shipment : BaseEntity
{
    [Key]
    public int ShipmentId { get; set; }

    public int CustomerId { get; set; }
    public virtual Customer Customer { get; set; }

    public int EmployeeId { get; set; }
    public virtual Employee Employee { get; set; }

    public int ShipmenttypeId { get; set; }
    public virtual ShipmentType Shipmenttype { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime ShipmentStartDate { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime ShipmentEndDate { get; set; }

    public bool IsPaid { get; set; } = false;

    public bool IsComplete { get; set; } = false;

    public double TotalPrice { get; set; }


    //[InverseProperty("Shipment")]
    //public virtual ICollection<Shipmentdetail> Shipmentdetails { get; set; } = new List<Shipmentdetail>();

}
