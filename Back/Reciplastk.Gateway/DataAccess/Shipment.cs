using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Reciplastk.Gateway.DataAccess;

[Table("shipment")]
public partial class Shipment
{
    [Key]
    [Column("shipmentid")]
    public int Shipmentid { get; set; }

    [Column("customerid")]
    public int Customerid { get; set; }

    [Column("employeeid")]
    public int Employeeid { get; set; }

    [Column("shipmenttypeid")]
    public int Shipmenttypeid { get; set; }

    [Column("shipmentstartdate", TypeName = "timestamp without time zone")]
    public DateTime Shipmentstartdate { get; set; }

    [Column("shipmentstartend", TypeName = "timestamp without time zone")]
    public DateTime Shipmentstartend { get; set; }

    [Column("ispaid")]
    public bool Ispaid { get; set; }

    [Column("iscomplete")]
    public bool Iscomplete { get; set; }

    [Column("creationdate", TypeName = "timestamp without time zone")]
    public DateTime Creationdate { get; set; }

    [Column("updatedate", TypeName = "timestamp without time zone")]
    public DateTime Updatedate { get; set; }

    [Column("isactive")]
    public bool Isactive { get; set; }

    [ForeignKey("Customerid")]
    [InverseProperty("Shipments")]
    public virtual Customer Customer { get; set; }

    [ForeignKey("Employeeid")]
    [InverseProperty("Shipments")]
    public virtual Employee Employee { get; set; }

    [InverseProperty("Shipment")]
    public virtual ICollection<Shipmentdetail> Shipmentdetails { get; set; } = new List<Shipmentdetail>();

    [ForeignKey("Shipmenttypeid")]
    [InverseProperty("Shipments")]
    public virtual Shipmenttype Shipmenttype { get; set; }
}
