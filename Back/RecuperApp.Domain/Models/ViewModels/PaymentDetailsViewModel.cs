using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecuperApp.Domain.Models.ViewModels
{
    public class PaymentDetailsViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public double Weight { get; set; }
        public int Price { get; set; }                     
                    
    }
}
