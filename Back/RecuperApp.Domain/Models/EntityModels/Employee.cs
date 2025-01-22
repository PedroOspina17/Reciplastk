using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RecuperApp.Domain.Models.EntityModels.Base;

namespace RecuperApp.Domain.Models.EntityModels;

public partial class Employee : BaseEntity
{
    [Key]
    public int EmployeeId { get; set; }

    public int? RoleId { get; set; }
    public virtual Role Role { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [Required]
    [StringLength(50)]
    public string LastName { get; set; }

    [Required]
    [StringLength(15)]
    public string DocumentNumber { get; set; }

    [Required]
    [StringLength(20)]
    public string UserName { get; set; }

    [Required]
    [StringLength(20)]
    public string Password { get; set; }

    [Required]
    [Column(TypeName = "timestamp without time zone")]
    public DateTime DateOfBirth { get; set; }

    [Required]
    [Column(TypeName = "timestamp without time zone")]
    public DateTime DateOfJoin { get; set; }


    //[InverseProperty("Employe")]
    //public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    //[InverseProperty("Employee")]
    //public virtual ICollection<Payrollconfig> Payrollconfigs { get; set; } = new List<Payrollconfig>();

    //[InverseProperty("Employee")]
    //public virtual ICollection<Productprice> Productprices { get; set; } = new List<Productprice>();

    //[InverseProperty("Employee")]
    //public virtual ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();

    //[InverseProperty("Employee")]
    //public virtual ICollection<Weightcontrol> Weightcontrols { get; set; } = new List<Weightcontrol>();
}
