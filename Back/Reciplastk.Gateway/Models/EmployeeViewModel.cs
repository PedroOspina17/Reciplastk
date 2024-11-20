using System.ComponentModel.DataAnnotations;

namespace Reciplastk.Gateway.Models
{
    public class EmployeeViewModel
    {
        public int? Employeeid { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(20)]
        public string UserName { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        public int Roleid { get; set; }
    }
}
