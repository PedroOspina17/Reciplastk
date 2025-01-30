using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecuperApp.Domain.Models.ViewModels
{
    public class PaymentViewModel
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public int TotalWeight { get; set; }
        public int TotalPrice { get; set; }
        public DateTime Date { get; set; }
        public List<PaymentDetailsViewModel> PaymentDetails  { get; set; }
        
    }
}
