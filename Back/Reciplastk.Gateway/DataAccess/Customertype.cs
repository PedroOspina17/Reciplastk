using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Reciplastk.Gateway.DataAccess;

[Table("customertype")]
public partial class Customertype
{
    [Key]
    [Column("customertypeid")]
    public int Customertypeid { get; set; }

    [Required]
    [Column("name")]
    [StringLength(50)]
    public string Name { get; set; }

    [Column("creationdate", TypeName = "timestamp without time zone")]
    public DateTime Creationdate { get; set; }

    [Column("isactive")]
    public bool Isactive { get; set; }

    [Column("description")]
    [StringLength(100)]
    public string Description { get; set; }

    [Column("updatedate", TypeName = "timestamp without time zone")]
    public DateTime? Updatedate { get; set; }

    [InverseProperty("Customertype")]
    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
