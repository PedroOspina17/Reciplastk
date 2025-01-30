using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RecuperApp.Common.Models;
using RecuperApp.Domain.Models.EntityModels;
using RecuperApp.Domain.Models.Requests;
using RecuperApp.Domain.Models.ViewModels;
using RecuperApp.Domain.Repositories;
using RecuperApp.Domain.Services.Interfaces;

namespace RecuperApp.Domain.Services
{
    public class PaymentService : ApplicationService<Payment, PaymentReceiptRequest>, IPaymentService
    {
        private readonly IWeightControlRepository weightControlRepository;

        public PaymentService(IApplicationRepository<Payment> applicationRepository, IMapper mapper, IWeightControlRepository weightControlRepository) : base(applicationRepository, mapper)
        {
            this.weightControlRepository = weightControlRepository;
        }

        public override async Task<Payment> Create(PaymentReceiptRequest viewModel)
        {
            var detailIdsToPay = viewModel.Products.Select(p => p.WeightControlDetailId).ToList();
            var updateTask = weightControlRepository.MarkWeightControlDetailsAsPaid(detailIdsToPay);
            var createTask = base.Create(viewModel); // ToDo:Verify the mapping !!
            //var newpayment = mapper.Map<Payment>(viewModel);
            //{
            //    EmployeeId = viewModel.EmployeeId,
            //    Date = DateTime.Now,
            //    TotalWeight = viewModel.TotalWeight,
            //    TotalPrice = viewModel.TotalToPay
            //};
            //db.Payments.Add(newpayment);
            //foreach (var i in viewModel.Products)
            //{
            //    var newDetail = new PaymentDetail
            //    {
            //        Payment = newpayment,
            //        WeightControlDetailId = i.WeightControlDetailId,
            //        ProductPrice = i.Price
            //    };
            //    db.PaymentDetails.Add(newDetail);
            //}
            //db.SaveChanges();
            //return response;
            await updateTask;
            return await createTask;

        }
        public async Task<List<PaymentViewModel>> GetAllReceipt()
        {
            var query = await applicationRepository.GetAllAsync(include: ["Employee"]);
            return mapper.Map<List<PaymentViewModel>>(query); // ToDo: Check if mapper can resolve this. is it necessary a mapper profile ? 

            //var bills = query.Select(p => new PaymentViewModel
            //{
            //    PaymentId = p.PaymentId,
            //    EmployeeName = p.Employee.Name,
            //    TotalWeight = p.TotalWeight,
            //    TotalPrice = p.TotalPrice,
            //    Date = p.Date
            //}).ToList();
            //return bills;
        }
        public async Task<PaymentViewModel> GetReceipt(int id)
        {
            var response = new HttpResponseModel();
            var query = await applicationRepository.FindByParamAsync(p => p.Id == id, include: ["Employee", "PaymentDetails"]);

            return mapper.Map<PaymentViewModel>(query);
            //    .Select(p => new
            //{
            //    p.PaymentId,
            //    EmployeeName = p.Employee.Name,
            //    totalWeight = p.TotalWeight,
            //    totalToPay = p.TotalPrice,
            //    p.Date,
            //    products = db.PaymentDetails.Where(x => x.PaymentId == id).Select(x => new PaymentDetailsViewModel
            //    {
            //        ProductId = x.WeightControlDetail.ProductId,
            //        ProductName = x.WeightControlDetail.Product.Name,
            //        Weight = x.WeightControlDetail.Weight,
            //        Price = x.ProductPrice,
            //    }).ToList(),
            //}).Where(x => ).FirstOrDefault();

        }
    }
}
