using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Reciplastk.Gateway.DataAccess;

[Table("weightcontrol")]
public partial class Weightcontrol
{
    [Key]
    [Column("weightcontrolid")]
    public int Weightcontrolid { get; set; }

    [Column("employeeid")]
    public int Employeeid { get; set; }

    [Column("productid")]
    public int Productid { get; set; }

    [Column("alternateid")]
    public int? Alternateid { get; set; }

    [Column("weight")]
    public decimal Weight { get; set; }

    [Column("ispaid")]
    public bool Ispaid { get; set; }

    [Column("creationdate", TypeName = "timestamp without time zone")]
    public DateTime Creationdate { get; set; }

    [Column("updatedate", TypeName = "timestamp without time zone")]
    public DateTime Updatedate { get; set; }

    [Column("isactive")]
    public bool Isactive { get; set; }

    [Column("date", TypeName = "timestamp without time zone")]
    public DateTime Date { get; set; }

    [ForeignKey("Employeeid")]
    [InverseProperty("Weightcontrols")]
    public virtual Employee Employee { get; set; }

    [ForeignKey("Productid")]
    [InverseProperty("Weightcontrols")]
    public virtual Product Product { get; set; }
}
