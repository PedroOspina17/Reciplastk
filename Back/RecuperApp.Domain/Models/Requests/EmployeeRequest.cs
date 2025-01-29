using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RecuperApp.Common.Exceptions;

namespace RecuperApp.Domain.Models.Requests
{
    public class EmployeeRequest
    {
        public int? Id { get; set; }
        /// <summary>
        /// Name of the empployee, cannot be greater than 50 characters
        /// </summary>
        /// <example>Pedro</example>
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// Last name of the employee, cannot be greater than 50 characters
        /// </summary>
        /// <example>Ospina Graciano</example>
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        /// <summary>
        /// Usar name for the employee to access to the platform, cannot be greater than 20 characters.
        /// </summary>
        /// <example>MyUserName</example>
        [Required]
        [StringLength(20)]
        public string UserName { get; set; }

        /// <summary>
        /// Password for the employee to access to the platform, cannot be greater than 50 characters.
        /// </summary>
        /// <example>1234</example>
        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        /// <summary>
        /// Identification for the employee, cannot be greater than 15 characters.
        /// </summary>
        /// <example>1554487979</example>
        [Required]
        [StringLength(15)]
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Date of birth of the employee.
        /// </summary>
        /// <example>1996/04/17</example>
        [Required]
        [Column(TypeName = "timestamp without time zone")]
        public DateTime DateOfBirth
        {
            get;
            set;            
        }

        /// <summary>
        /// Date of join of the employee to the company.
        /// </summary>
        /// <example>1996/04/17</example>
        [Required]
        [Column(TypeName = "timestamp without time zone")]
        public DateTime DateOfJoin { get; set; }
        
        /// <summary>
        /// Role assigned to the employee. Make sure it is an already created value.
        /// </summary>
        [Required]
        public int Roleid { get; set; }
    }
}
