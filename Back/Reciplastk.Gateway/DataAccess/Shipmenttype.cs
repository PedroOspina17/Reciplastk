using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Reciplastk.Gateway.DataAccess;

[Table("shipmenttype")]
public partial class Shipmenttype
{
    [Key]
    [Column("shipmenttypeid")]
    public int Shipmenttypeid { get; set; }

    [Required]
    [Column("name")]
    [StringLength(50)]
    public string Name { get; set; }

    [Column("description")]
    [StringLength(50)]
    public string Description { get; set; }

    [Column("creationdate", TypeName = "timestamp without time zone")]
    public DateTime Creationdate { get; set; }

    [Column("updatedate", TypeName = "timestamp without time zone")]
    public DateTime Updatedate { get; set; }

    [Column("isactive")]
    public bool Isactive { get; set; }

    [InverseProperty("Shipmenttype")]
    public virtual ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();
}
