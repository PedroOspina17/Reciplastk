using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Reciplastk.Gateway.DataAccess;

[Table("remainings")]
public partial class Remaining
{
    [Key]
    [Column("remainingid")]
    public int Remainingid { get; set; }

    [Column("weightcontrolid")]
    public int Weightcontrolid { get; set; }

    [Column("productid")]
    public int Productid { get; set; }

    [Column("weight")]
    public double Weight { get; set; }

    [Column("creationdate", TypeName = "timestamp without time zone")]
    public DateTime Creationdate { get; set; }

    [Column("updatedate", TypeName = "timestamp without time zone")]
    public DateTime Updatedate { get; set; }

    [Column("isactive")]
    public bool Isactive { get; set; }

    [ForeignKey("Weightcontrolid")]
    [InverseProperty("Remainings")]
    public virtual Weightcontrol Weightcontrol { get; set; }
}
