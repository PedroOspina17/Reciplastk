using System.ComponentModel.DataAnnotations;
using RecuperApp.Domain.Models.EntityModels.Base;

namespace RecuperApp.Domain.Models.EntityModels;

public class PaymentDetail : BaseEntity
{
    [Key]
    public int PaymentsDetailId { get; set; }

    public int PaymentId { get; set; }
    public virtual Payment Payment { get; set; }

    public int? WeightControlDetailId { get; set; }
    public virtual WeightControlDetail WeightControlDetail { get; set; }

    public int ProductPrice { get; set; }


}
