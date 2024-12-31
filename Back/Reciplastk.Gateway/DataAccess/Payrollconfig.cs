using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Reciplastk.Gateway.DataAccess;

[Keyless]
[Table("payrollconfig")]
public partial class Payrollconfig
{
    [Column("productid")]
    public int Productid { get; set; }

    [Column("employeeid")]
    public int Employeeid { get; set; }

    [Column("priceperkilo")]
    public double Priceperkilo { get; set; }

    [Column("iscurrentprice")]
    public bool Iscurrentprice { get; set; }

    [Column("creationdate", TypeName = "timestamp without time zone")]
    public DateTime Creationdate { get; set; }

    [Column("updatedate", TypeName = "timestamp without time zone")]
    public DateTime Updatedate { get; set; }

    [Column("isactive")]
    public bool Isactive { get; set; }

    [ForeignKey("Employeeid")]
    public virtual Employee Employee { get; set; }

    [ForeignKey("Productid")]
    public virtual Product Product { get; set; }
}
