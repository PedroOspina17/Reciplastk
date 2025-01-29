using System.ComponentModel.DataAnnotations;
using RecuperApp.Domain.Models.EntityModels.Base;

namespace RecuperApp.Domain.Models.EntityModels;

public class PayrollConfig : BaseEntity
{
    public int ProductId { get; set; }
    public virtual Product Product { get; set; }

    public int EmployeeId { get; set; }
    public virtual Employee Employee { get; set; }

    public double PricePerKilo { get; set; }

    public bool IsCurrentPrice { get; set; } = false;


}
