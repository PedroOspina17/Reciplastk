using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Reciplastk.Gateway.DataAccess;

[Table("test")]
public partial class Test
{
    [Key]
    [Column("testid")]
    public int Testid { get; set; }

    [Required]
    [Column("name")]
    [StringLength(50)]
    public string Name { get; set; }

    [Column("lastname")]
    [StringLength(50)]
    public string Lastname { get; set; }

    [InverseProperty("Test")]
    public virtual ICollection<Secondarytabletest> Secondarytabletests { get; set; } = new List<Secondarytabletest>();
}
