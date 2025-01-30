using RecuperApp.Domain.Models.EntityModels;
using RecuperApp.Domain.Models.ViewModels;

namespace RecuperApp.Domain.Repositories
{
    public interface IPaymentsRepository : IApplicationRepository<Payment>
    {
        Task<List<PaymentViewModel>> GetAllReceipt();
        Task<PaymentViewModel> GetReceipt(int id);
    }
}