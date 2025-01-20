using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Reciplastk.Gateway.DataAccess;

[Table("products")]
public partial class Product
{
    [Key]
    [Column("productid")]
    public int Productid { get; set; }

    [Required]
    [Column("shortname")]
    [StringLength(50)]
    public string Shortname { get; set; }

    [Required]
    [Column("name")]
    [StringLength(50)]
    public string Name { get; set; }

    [Required]
    [Column("description")]
    [StringLength(150)]
    public string Description { get; set; }

    [Required]
    [Column("code")]
    [StringLength(10)]
    public string Code { get; set; }

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

    [InverseProperty("Parent")]
    public virtual ICollection<Product> InverseParent { get; set; } = new List<Product>();

    [ForeignKey("Parentid")]
    [InverseProperty("InverseParent")]
    public virtual Product Parent { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<Payrollconfig> Payrollconfigs { get; set; } = new List<Payrollconfig>();

    [InverseProperty("Product")]
    public virtual ICollection<Productprice> Productprices { get; set; } = new List<Productprice>();

    [InverseProperty("Product")]
    public virtual ICollection<Remaining> Remainings { get; set; } = new List<Remaining>();

    [InverseProperty("Product")]
    public virtual ICollection<Shipmentdetail> Shipmentdetails { get; set; } = new List<Shipmentdetail>();

    [InverseProperty("Product")]
    public virtual ICollection<Weightcontroldetail> Weightcontroldetails { get; set; } = new List<Weightcontroldetail>();
}
