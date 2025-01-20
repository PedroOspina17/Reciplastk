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

        public List<EmployeeComparisonsViewModel> GetEmployeeComparisonInfo(bool yearlyChart = true, int year = 2025, int month = 1)
        {

            var bins = yearlyChart ? Enumerable.Range(1, 12) : Enumerable.Range(1, 31);

            var queryGroups = db.Weightcontroldetails
                .Where(p => p.Weightcontrol.Creationdate.Year == year && (yearlyChart || p.Weightcontrol.Creationdate.Month == month)) // Filter by year or month
                .Select(p => new
                {
                    p.Weightcontrol.Employeeid,
                    p.Weightcontrol.Employee.Name,
                    p.Weight,
                    Bin = (yearlyChart ? p.Weightcontrol.Creationdate.Month : p.Weightcontrol.Creationdate.Day),
                    p.Weightcontrol.Creationdate
                })
                .GroupBy(p => p.Employeeid);
            var result = new List<EmployeeComparisonsViewModel>();
            foreach (var group in queryGroups)
            {
                var g = group.GroupBy(g => g.Bin).Select(x => new { x.Key, Value = x.Sum(s => s.Weight) }).ToDictionary(p => p.Key);
                result.Add(
                    group.Select(p => new EmployeeComparisonsViewModel
                    {
                        EmployeeId = p.Employeeid,
                        label = p.Name,
                        data = bins.Select(x => g.ContainsKey(x) ? g[x].Value : 0).ToList(),
                        //chartLabels = bins.Select(x => x.ToString()).ToList()
                    }).FirstOrDefault()
                );
            }
            return result;
        }
    }
}
