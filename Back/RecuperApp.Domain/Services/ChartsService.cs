using Microsoft.Extensions.Logging;
using RecuperApp.Common.Exceptions;
using RecuperApp.Domain.Models.ViewModels;
using RecuperApp.Domain.Repositories;

namespace RecuperApp.Domain.Services
{
    public class ChartsService
    {
        private readonly ReciplastkContext db;
        private readonly ILogger<ChartsService> logger;

        public ChartsService(ReciplastkContext db, ILogger<ChartsService> logger)
        {
            this.db = db;
            this.logger = logger;
        }

        public List<EmployeeComparisonsViewModel> GetEmployeeComparisonInfo(bool yearlyChart = true, int year = 2025, int month = 1)
        {
            var bins = yearlyChart ? Enumerable.Range(1, 12) : Enumerable.Range(1, 31);

            var queryGroups = db.WeightControlDetails
                .Where(p => p.WeightControl.CreatedDate.Year == year && (yearlyChart || p.WeightControl.CreatedDate.Month == month)) // Filter by year or month
                .Select(p => new
                {
                    p.WeightControl.EmployeeId,
                    p.WeightControl.Employee.Name,
                    p.Weight,
                    Bin = (yearlyChart ? p.WeightControl.CreatedDate.Month : p.WeightControl.CreatedDate.Day),
                    p.WeightControl.CreatedDate
                })
                .GroupBy(p => p.EmployeeId);
            var result = new List<EmployeeComparisonsViewModel>();
            foreach (var group in queryGroups)
            {
                var g = group.GroupBy(g => g.Bin).Select(x => new { x.Key, Value = x.Sum(s => s.Weight) }).ToDictionary(p => p.Key);
                result.Add(
                    group.Select(p => new EmployeeComparisonsViewModel
                    {
                        EmployeeId = p.EmployeeId,
                        Label = p.Name,
                        Data = bins.Select(x => g.ContainsKey(x) ? g[x].Value : 0).ToList(),
                        //chartLabels = bins.Select(x => x.ToString()).ToList()
                    }).FirstOrDefault()
                );
            }
            return result;
        }
    }
}
