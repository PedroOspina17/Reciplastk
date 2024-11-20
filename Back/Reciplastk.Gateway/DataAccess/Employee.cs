using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Reciplastk.Gateway.DataAccess;

[Table("employee")]
public partial class Employee
{
    [Key]
    [Column("employeeid")]
    public int Employeeid { get; set; }

    [Column("roleid")]
    public int? Roleid { get; set; }

    [Required]
    [Column("name")]
    [StringLength(50)]
    public string Name { get; set; }

    [Required]
    [Column("lastname")]
    [StringLength(50)]
    public string Lastname { get; set; }

    [Required]
    [Column("username")]
    [StringLength(20)]
    public string Username { get; set; }

    [Required]
    [Column("password")]
    [StringLength(20)]
    public string Password { get; set; }

    [Column("creationdate", TypeName = "timestamp without time zone")]
    public DateTime Creationdate { get; set; }

    [Column("updateddate", TypeName = "timestamp without time zone")]
    public DateTime? Updateddate { get; set; }

    [Column("isactive")]
    public bool Isactive { get; set; }

    [InverseProperty("Employe")]
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    [ForeignKey("Roleid")]
    [InverseProperty("Employees")]
    public virtual Rol Role { get; set; }

    [InverseProperty("Employee")]
    public virtual ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();

    [InverseProperty("Employee")]
    public virtual ICollection<Weightcontrol> Weightcontrols { get; set; } = new List<Weightcontrol>();
}
