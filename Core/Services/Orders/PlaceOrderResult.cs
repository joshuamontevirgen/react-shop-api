using Core.Domain.Orders;
using Core.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Orders
{
    public class PlaceOrderResult
    {
        public Order Order { get; set; }
        public ProcessPaymentResult PaymentProcess { get; set; }
    }
}
