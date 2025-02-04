using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecuperApp.Common.Models;
using RecuperApp.Domain.Models.EntityModels;
using RecuperApp.Domain.Models.Requests;
using RecuperApp.Domain.Models.ViewModels;
using static RecuperApp.Domain.Models.Enums;

namespace RecuperApp.Domain.Repositories
{
    public class WeightControlRepository : ApplicationRepository<WeightControl>, IWeightControlRepository
    {
        public WeightControlRepository(ReciplastkContext context) : base(context) { }


        /// <summary>
        /// Mark all the weight control header as paid for all the weight control detail ids provided.
        /// </summary>
        /// <param name="weightControlDetailIds">The list of all weight control detail ids to be marked as paid</param>
        /// <returns></returns>
        public async Task MarkWeightControlDetailsAsPaid(List<int> weightControlDetailIds)
        {
            List<Task> tasks = [];
            foreach (var id in weightControlDetailIds)
            {
                var detail = db.WeightControlDetails.Where(x => x.Id == id).FirstOrDefault();
                if (detail != null)
                {
                    var weightcontrol = db.WeightControls.Where(x => x.Id == detail.WeightControlId).FirstOrDefault();
                    if (weightcontrol != null)
                    {
                        weightcontrol.IsPaid = true;
                        tasks.Add(db.SaveChangesAsync());
                    }   
                }
            }
            await Task.WhenAll(tasks);
        }

        public async Task<List<GroundProductViewModel>> GetGroundProducts() 
        {
            var response = new HttpResponseModel();
            var query = await db.WeightControlDetails
                .Where(w => w.WeightControl.IsActive &&
                            w.WeightControl.WeightControlTypeId == WeightControlTypeTypeEnum.Grinding.GetHashCode() &&
                            w.WeightControl.DateStart > DateTime.Today &&
                            w.WeightControl.DateStart < DateTime.Today.AddDays(1))
                .Select(w => new GroundProductViewModel()
                {
                    Id = w.Id,
                    ControlId = w.WeightControlId,
                    Weight = w.Weight,
                    ProductName = w.Product.Name,
                    DateStart = w.WeightControl.DateStart,
                    Remaining = db.Remainings.Where(r => r.WeightControlId == w.WeightControlId).FirstOrDefault().Weight,
                })
            .OrderByDescending(w => w.Id)
            .ToListAsync();
            return query;
        }

        public async Task<List<WeightControlReportViewModel>> Filter(WeightControlReportRequest viewModel)
        {
            var query = db.WeightControlDetails.Where(p => p.WeightControl.IsActive == true);
            if (viewModel.ProductId != null && viewModel.ProductId != -1)
            {
                query = query.Where(p => p.ProductId == viewModel.ProductId);
            }
            if (viewModel.EmployeeId != null && viewModel.EmployeeId != -1)
            {
                query = query.Where(p => p.WeightControl.EmployeeId == viewModel.EmployeeId);
            }
            if (viewModel.StartDate != null)
            {
                query = query.Where(p => p.WeightControl.DateStart >= viewModel.StartDate);
            }
            if (viewModel.EndDate != null)
            {
                query = query.Where(p => p.WeightControl.DateStart <= viewModel.EndDate);
            }
            if (viewModel.IsPaid != null)
            {
                query = query.Where(p => p.WeightControl.IsPaid == viewModel.IsPaid);
            }
            if (viewModel.Type != null && viewModel.Type != -1)
            {
                query = query.Where(p => p.WeightControl.WeightControlTypeId == viewModel.Type);
            }
            var result = await query.Select(p => new WeightControlReportViewModel
            {
                ProductId = p.ProductId,
                WeightControlDetailId = p.Id,
                Date = p.WeightControl.DateStart,
                ProductName = p.Product.Name,
                EmployeeName = p.WeightControl.Employee.Name,
                Weight = p.Weight,
                Type = p.WeightControl.WeightControlType.Name,
                SubTotal = p.Weight * db.PayrollConfigs.Where(x =>
                                                    (x.ProductId == p.ProductId || x.ProductId == p.Product.ParentId) 
                                                    && x.EmployeeId == p.WeightControl.EmployeeId 
                                                    && x.IsCurrentPrice)
                                                .Select(y=> y.PricePerKilo).FirstOrDefault(),                
            }).ToListAsync();

            return result;
        }

    }
}
