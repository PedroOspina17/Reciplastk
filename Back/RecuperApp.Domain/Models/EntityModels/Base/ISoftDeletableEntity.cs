namespace RecuperApp.Domain.Models.EntityModels.Base
{
    public interface ISoftDeletableEntity
    {
        public bool IsActive { get; set; }
    }
}
