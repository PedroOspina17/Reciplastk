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

    [Required]
    [Column("shortname")]
    [StringLength(20)]
    public string Shortname { get; set; }

    [Required]
    [Column("name")]
    [StringLength(50)]
    public string Name { get; set; }

    [Required]
    [Column("description")]
    [StringLength(50)]
    public string Description { get; set; }

    [Required]
    [Column("code")]
    [StringLength(10)]
    public string Code { get; set; }

    [Column("buyprice")]
    public decimal Buyprice { get; set; }

    [Column("sellprice")]
    public decimal Sellprice { get; set; }

    [Column("margin")]
    public decimal Margin { get; set; }

    [Column("issubtype")]
    public bool Issubtype { get; set; }

    [Column("creationdate", TypeName = "timestamp without time zone")]
    public DateTime Creationdate { get; set; }

    [Column("updatedate", TypeName = "timestamp without time zone")]
    public DateTime Updatedate { get; set; }

    [Column("isactive")]
    public bool Isactive { get; set; }

    [Column("parentid")]
    public int? Parentid { get; set; }

    [ForeignKey("Customerid")]
    [InverseProperty("Productprices")]
    public virtual Customer Customer { get; set; }

    [ForeignKey("Productid")]
    [InverseProperty("Productprices")]
    public virtual Product Product { get; set; }
}
