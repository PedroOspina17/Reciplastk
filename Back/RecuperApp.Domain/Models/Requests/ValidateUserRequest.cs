using System.ComponentModel.DataAnnotations;

namespace RecuperApp.Domain.Models.Requests
{
    public class ValidateUserRequest
    {
        [Required]
        [StringLength(20)]
        public string UserName { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
    }
}
