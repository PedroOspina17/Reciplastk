using System.ComponentModel.DataAnnotations;
using RecuperApp.Domain.Models.EntityModels.Base;

namespace RecuperApp.Domain.Models.EntityModels;

public class ProductPrice : BaseEntity
{

    public int ProductId { get; set; }
    public virtual Product Product { get; set; }

    public int CustomerId { get; set; }
    public virtual Customer Customer { get; set; }

    public int PricetypeId { get; set; }
    public virtual PriceType Pricetype { get; set; }

    public int EmployeeId { get; set; }
    public virtual Employee Employee { get; set; }

    public double Price { get; set; }

    public bool IsCurrentPrice { get; set; } = false;


}
