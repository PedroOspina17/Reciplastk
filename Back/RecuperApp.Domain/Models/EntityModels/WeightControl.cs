using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RecuperApp.Domain.Models.EntityModels.Base;

namespace RecuperApp.Domain.Models.EntityModels;

public class WeightControl : BaseEntity
{
    [Key]
    public int WeightControlId { get; set; }

    public int EmployeeId { get; set; }
    public virtual Employee Employee { get; set; }

    public int WeightControlTypeId { get; set; }
    public virtual WeightControlType WeightControlType { get; set; }

    public bool IsPaid { get; set; } = false;

    [Column(TypeName = "timestamp without time zone")]
    public DateTime DateStart { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime DateEnd { get; set; }

    //[InverseProperty("Weightcontrol")]
    //public virtual ICollection<Weightcontroldetail> Weightcontroldetails { get; set; } = new List<Weightcontroldetail>();

    //[InverseProperty("Weightcontrol")]
    //public virtual ICollection<Remaining> Remainings { get; set; } = new List<Remaining>();


}
