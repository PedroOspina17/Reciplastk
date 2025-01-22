using System.ComponentModel.DataAnnotations;
using RecuperApp.Domain.Models.EntityModels.Base;

namespace RecuperApp.Domain.Models.EntityModels;

public class Remaining : BaseEntity
{
    [Key]
    public int RemainingId { get; set; }

    public int WeightControlId { get; set; }
    public virtual WeightControl WeightControl { get; set; }

    public int ProductId { get; set; }
    public virtual Product Product { get; set; }

    public double Weight { get; set; }


}
