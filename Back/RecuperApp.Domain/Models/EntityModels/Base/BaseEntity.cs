using System.ComponentModel.DataAnnotations.Schema;

namespace RecuperApp.Domain.Models.EntityModels.Base
{
    public class BaseEntity : IAuditableEntity, ISoftDeletableEntity
    {
        [Column(TypeName = "timestamp without time zone")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public DateTime? UpdatedDate { get; set; } = null;
        public string UpdatedBy { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
