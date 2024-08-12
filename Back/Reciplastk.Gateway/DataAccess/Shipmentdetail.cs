using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Reciplastk.Gateway.DataAccess;

[Table("shipmentdetail")]
public partial class Shipmentdetail
{
    [Key]
    [Column("shipmentdetailid")]
    public int Shipmentdetailid { get; set; }

    [Column("shipmentid")]
    public int Shipmentid { get; set; }

    [Column("productid")]
    public int Productid { get; set; }

    [Column("shipmentdate", TypeName = "timestamp without time zone")]
    public DateTime Shipmentdate { get; set; }

    [Column("weight")]
    public double Weight { get; set; }

    [ForeignKey("Productid")]
    [InverseProperty("Shipmentdetails")]
    public virtual Product Product { get; set; }

    [ForeignKey("Shipmentid")]
    [InverseProperty("Shipmentdetails")]
    public virtual Shipment Shipment { get; set; }
}
