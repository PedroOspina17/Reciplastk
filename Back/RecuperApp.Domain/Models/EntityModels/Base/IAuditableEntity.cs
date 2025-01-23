namespace RecuperApp.Domain.Models.EntityModels.Base
{
    public interface IAuditableEntity
    {
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }


    }
}
