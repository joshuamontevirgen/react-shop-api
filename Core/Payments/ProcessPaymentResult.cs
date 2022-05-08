using Core.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Payments
{
    public class ProcessPaymentResult
    {
        public ProcessPaymentResult()
        {
            Errors = new List<string>();
            NewPaymentStatus = PaymentStatus.Pending;
        }
        public bool Success { get => Errors.Any(); }
        public IEnumerable<string> Errors { get; set; }

        public string RedirectUrl { get; set; }
        public string ThirdPartyPaymentId { get; set; }
        public PaymentStatus NewPaymentStatus { get; set; } 
    }
}
