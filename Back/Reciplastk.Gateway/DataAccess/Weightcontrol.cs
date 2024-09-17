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
    public int? Employeeid { get; set; }

    [Column("weightcontroltypeid")]
    public int? Weightcontroltypeid { get; set; }

    [Column("ispaid")]
    public bool Ispaid { get; set; }

    [Column("datestart", TypeName = "timestamp without time zone")]
    public DateTime Datestart { get; set; }

    [Column("dateend", TypeName = "timestamp without time zone")]
    public DateTime Dateend { get; set; }

    [Column("creationdate", TypeName = "timestamp without time zone")]
    public DateTime Creationdate { get; set; }

    [Column("updatedate", TypeName = "timestamp without time zone")]
    public DateTime Updatedate { get; set; }

    [Column("isactive")]
    public bool Isactive { get; set; }

    [ForeignKey("Employeeid")]
    [InverseProperty("Weightcontrols")]
    public virtual Employee Employee { get; set; }

    [ForeignKey("Weightcontroltypeid")]
    [InverseProperty("Weightcontrols")]
    public virtual Weightcontroltype Weightcontroltype { get; set; }
}
