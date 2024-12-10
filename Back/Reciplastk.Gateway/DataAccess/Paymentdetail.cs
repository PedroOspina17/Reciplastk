using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Reciplastk.Gateway.DataAccess;

[Table("paymentdetails")]
public partial class Paymentdetail
{
    [Key]
    [Column("paymentsdetailid")]
    public int Paymentsdetailid { get; set; }

    [Column("paymentid")]
    public int Paymentid { get; set; }

    [Column("weightcontroldetailid")]
    public int? Weightcontroldetailid { get; set; }

    [Column("productprice")]
    public int Productprice { get; set; }

    [ForeignKey("Paymentid")]
    [InverseProperty("Paymentdetails")]
    public virtual Payment Payment { get; set; }

    [ForeignKey("Weightcontroldetailid")]
    [InverseProperty("Paymentdetails")]
    public virtual Weightcontroldetail Weightcontroldetail { get; set; }
}
