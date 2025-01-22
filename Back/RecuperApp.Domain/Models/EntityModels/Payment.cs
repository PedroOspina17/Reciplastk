using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RecuperApp.Domain.Models.EntityModels.Base;

namespace RecuperApp.Domain.Models.EntityModels;
public class Payment : BaseEntity
{
    [Key]
    public int PaymentId { get; set; }

    public int EmployeeId { get; set; }
    public virtual Employee Employee { get; set; }

    public int TotalWeight { get; set; }

    public int TotalPrice { get; set; }
    
    [Column(TypeName = "timestamp without time zone")]
    public DateTime Date { get; set; }


    //[InverseProperty("Payment")]
    //public virtual ICollection<Paymentdetail> Paymentdetails { get; set; } = new List<Paymentdetail>();
}
