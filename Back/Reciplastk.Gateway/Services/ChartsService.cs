using Azure.Core;
using Reciplastk.Gateway.DataAccess;
using Reciplastk.Gateway.Models;

namespace Reciplastk.Gateway.Services
{
    public class ChartsService
    {
        private readonly ReciplastkContext db;

        public ChartsService(ReciplastkContext db)
        {
            this.db = db;
        }
        public List<EmployeeComparisonsViewModel> GetEmployeeComparisonInfo()
        {
            var months = Enumerable.Range(1, 12);
            var queryGroups = db.Weightcontroldetails
                .Where(p => p.Weightcontrol.Creationdate > DateTime.Now.AddMonths(-12))
                .Select(p => new { p.Weightcontrol.Employeeid, p.Weightcontrol.Employee.Name, p.Weight, p.Weightcontrol.Creationdate.Month })
                .GroupBy(p => p.Employeeid);
            var result = new List<EmployeeComparisonsViewModel>();
            foreach (var group in queryGroups)
            {
                var g = group.GroupBy(g => g.Month).Select(x => new { x.Key, Value = x.Sum(s => s.Weight) }).ToDictionary(p => p.Key);
                result.Add(
                    group.Select(p => new EmployeeComparisonsViewModel
                    {
                        EmployeeId = p.Employeeid,
                        EmployeeName = p.Name,
                        WeightByMonth = months.Select(x => g.ContainsKey(x) ? g[x].Value : 0).ToList()
                    }).FirstOrDefault()
                );
            }
            return result;
        }
    }
}
