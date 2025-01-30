using System.ComponentModel.DataAnnotations;
using RecuperApp.Domain.Models.EntityModels.Base;

namespace RecuperApp.Domain.Models.EntityModels;

public class PriceType : BaseEntity
{

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [Required]
    [StringLength(150)]
    public string Description { get; set; }

    //[InverseProperty("Pricetype")]
    //public virtual ICollection<Productprice> Productprices { get; set; } = new List<Productprice>();
}
