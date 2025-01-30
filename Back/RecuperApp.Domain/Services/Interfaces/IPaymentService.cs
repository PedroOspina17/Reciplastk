using RecuperApp.Domain.Models.EntityModels;
using RecuperApp.Domain.Models.Requests;
using RecuperApp.Domain.Models.ViewModels;

namespace RecuperApp.Domain.Services.Interfaces
{
    public interface IPaymentService : IApplicationService<Payment, PaymentReceiptRequest>
    {
        Task<List<PaymentViewModel>> GetAllReceipt();
        Task<PaymentViewModel> GetReceipt(int id);
    }
}