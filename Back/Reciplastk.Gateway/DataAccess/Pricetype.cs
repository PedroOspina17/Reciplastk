using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Reciplastk.Gateway.DataAccess;

[Table("pricetype")]
public partial class Pricetype
{
    [Key]
    [Column("pricetypeid")]
    public int Pricetypeid { get; set; }

    [Required]
    [Column("name")]
    [StringLength(50)]
    public string Name { get; set; }

    [Required]
    [Column("description")]
    [StringLength(150)]
    public string Description { get; set; }

    [Column("creationdate", TypeName = "timestamp without time zone")]
    public DateTime Creationdate { get; set; }

    [Column("updatedate", TypeName = "timestamp without time zone")]
    public DateTime Updatedate { get; set; }

    [Column("isactive")]
    public bool Isactive { get; set; }

    [InverseProperty("Pricetype")]
    public virtual ICollection<Productprice> Productprices { get; set; } = new List<Productprice>();
}
