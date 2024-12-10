using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Reciplastk.Gateway.DataAccess;

[Table("productprice")]
public partial class Productprice
{
    [Key]
    [Column("productpriceid")]
    public int Productpriceid { get; set; }

    [Column("productid")]
    public int Productid { get; set; }

    [Column("customerid")]
    public int Customerid { get; set; }

    [Column("pricetypeid")]
    public int Pricetypeid { get; set; }

    [Column("price")]
    public double Price { get; set; }

    [Column("creationdate", TypeName = "timestamp without time zone")]
    public DateTime Creationdate { get; set; }

    [Column("updatedate", TypeName = "timestamp without time zone")]
    public DateTime Updatedate { get; set; }

    [Column("isactive")]
    public bool Isactive { get; set; }

    [Column("employeeid")]
    public int Employeeid { get; set; }

    [ForeignKey("Customerid")]
    [InverseProperty("Productprices")]
    public virtual Customer Customer { get; set; }

    [ForeignKey("Employeeid")]
    [InverseProperty("Productprices")]
    public virtual Employee Employee { get; set; }

    [ForeignKey("Pricetypeid")]
    [InverseProperty("Productprices")]
    public virtual Pricetype Pricetype { get; set; }

    [ForeignKey("Productid")]
    [InverseProperty("Productprices")]
    public virtual Product Product { get; set; }
}
