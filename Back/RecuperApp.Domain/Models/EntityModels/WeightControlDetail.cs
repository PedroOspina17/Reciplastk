using System.ComponentModel.DataAnnotations;
using RecuperApp.Domain.Models.EntityModels.Base;

namespace RecuperApp.Domain.Models.EntityModels;

public class WeightControlDetail : BaseEntity
{
    public int WeightControlId { get; set; }
    public virtual WeightControl WeightControl { get; set; }

    public int ProductId { get; set; }
    public virtual Product Product { get; set; }

    public double Weight { get; set; }

    //[InverseProperty("Weightcontroldetail")]
    //public virtual ICollection<Paymentdetail> Paymentdetails { get; set; } = new List<Paymentdetail>();


}
