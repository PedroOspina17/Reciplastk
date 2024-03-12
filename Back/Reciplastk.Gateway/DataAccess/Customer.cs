using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Reciplastk.Gateway.DataAccess;

[Table("customer")]
public partial class Customer
{
    [Key]
    [Column("customerid")]
    public int Customerid { get; set; }

    [Column("nit")]
    [StringLength(50)]
    public string Nit { get; set; }

    [Required]
    [Column("name")]
    [StringLength(50)]
    public string Name { get; set; }

    [Required]
    [Column("lastname")]
    [StringLength(50)]
    public string Lastname { get; set; }

    [Column("address")]
    [StringLength(50)]
    public string Address { get; set; }

    [Column("cell")]
    [StringLength(10)]
    public string Cell { get; set; }

    [Column("clientsince", TypeName = "timestamp without time zone")]
    public DateTime? Clientsince { get; set; }

    [Column("needspickup")]
    public bool? Needspickup { get; set; }

    [Column("createddate", TypeName = "timestamp without time zone")]
    public DateTime Createddate { get; set; }

    [Column("updateddate", TypeName = "timestamp without time zone")]
    public DateTime? Updateddate { get; set; }

    [Column("isactive")]
    public bool? Isactive { get; set; }
}
