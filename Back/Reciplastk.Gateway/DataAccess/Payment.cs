using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Reciplastk.Gateway.DataAccess;

[Table("payment")]
public partial class Payment
{
    [Key]
    [Column("paymentid")]
    public int Paymentid { get; set; }

    [Column("employeid")]
    public int Employeid { get; set; }

    [Column("totalweight")]
    public int Totalweight { get; set; }

    [Column("totalprice")]
    public int Totalprice { get; set; }

    [Column("date", TypeName = "timestamp without time zone")]
    public DateTime Date { get; set; }

    [ForeignKey("Employeid")]
    [InverseProperty("Payments")]
    public virtual Employee Employe { get; set; }

    [InverseProperty("Payment")]
    public virtual ICollection<Paymentdetail> Paymentdetails { get; set; } = new List<Paymentdetail>();
}
