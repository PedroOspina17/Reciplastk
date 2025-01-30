using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecuperApp.Common.Models;
using RecuperApp.Domain.Models.EntityModels;
using RecuperApp.Domain.Models.ViewModels;

namespace RecuperApp.Domain.Repositories
{
    public class PaymentsRepository : ApplicationRepository<Payment>, IPaymentsRepository
    {
        public PaymentsRepository(ReciplastkContext _context) : base(_context)
        {
        }
        public async Task<List<PaymentViewModel>> GetAllReceipt() // ToDo: Check if i can replace with Generic repository sending new include params.
        {

            var bills = await db.Payments.Include(p => p.Employee).Select(p => new PaymentViewModel
            {
                Id = p.Id,
                EmployeeName = p.Employee.Name,
                TotalWeight = p.TotalWeight,
                TotalPrice = p.TotalPrice,
                Date = p.Date
            }).ToListAsync();
            return bills;
        }
        public async Task<PaymentViewModel> GetReceipt(int id)
        {
            var query = await db.Payments.Include(p => p.Employee).Select(p => new PaymentViewModel
            {
                Id = p.Id,
                EmployeeName = p.Employee.Name,
                TotalWeight = p.TotalWeight,
                TotalPrice = p.TotalPrice,
                Date = p.Date,
                PaymentDetails = db.PaymentDetails.Where(x => x.PaymentId == id).Select(x => new PaymentDetailsViewModel
                {
                    Id = x.WeightControlDetail.ProductId,
                    ProductName = x.WeightControlDetail.Product.Name,
                    Weight = x.WeightControlDetail.Weight,
                    Price = x.ProductPrice,
                }).ToList(),
            }).Where(x => x.Id == id).FirstOrDefaultAsync();

            return query;
        }
    }
}
