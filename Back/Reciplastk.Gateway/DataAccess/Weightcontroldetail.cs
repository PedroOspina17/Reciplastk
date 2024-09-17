using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Reciplastk.Gateway.DataAccess;

[Table("weightcontroldetail")]
public partial class Weightcontroldetail
{
    [Key]
    [Column("weightcontroldetailid")]
    public int Weightcontroldetailid { get; set; }

    [Column("weightcontrolid")]
    public int? Weightcontrolid { get; set; }

    [Column("productid")]
    public int? Productid { get; set; }

    [Column("weight")]
    public double Weight { get; set; }

    [ForeignKey("Productid")]
    [InverseProperty("Weightcontroldetails")]
    public virtual Product Product { get; set; }

    [ForeignKey("Weightcontrolid")]
    [InverseProperty("Weightcontroldetails")]
    public virtual Weightcontrol Weightcontrol { get; set; }
}
