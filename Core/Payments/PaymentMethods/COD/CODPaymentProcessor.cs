using Core.Payments.PaymentMethods.Paymaya.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Payments.PaymentMethods.COD
{
    public class CODPaymentProcessor : ICODPaymentMethod
    {
        ICheckoutService _checkoutService;
        public CODPaymentProcessor(ICheckoutService checkoutService)
        {
            _checkoutService = checkoutService;
        }

        public string Name => "COD";

        public async Task<ProcessPaymentResult> ProcessPaymentAsync(ProcessPaymentRequest processPaymentRequest)
        {
            var response = await _checkoutService.CreateOrderAsync(processPaymentRequest.OrderId);
            var result = new ProcessPaymentResult
            {
               
            };
            return result;
        }
    }
}
