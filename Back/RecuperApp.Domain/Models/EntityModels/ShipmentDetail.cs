using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RecuperApp.Domain.Models.EntityModels.Base;

namespace RecuperApp.Domain.Models.EntityModels;

public class ShipmentDetail : BaseEntity
{
    public int ShipmentId { get; set; }
    public virtual Shipment Shipment { get; set; }

    public int ProductId { get; set; }
    public virtual Product Product { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime ShipmentDate { get; set; }

    public double Weight { get; set; }

    public double Subtotal { get; set; }

    public double ProductPrice { get; set; }


}
