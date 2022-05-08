using Core.Payments;
using Core.Payments.PaymentMethods.Paymaya.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Payments.PaymentMethods.Paymaya
{
    public class PaymayaPaymentProcessor : IPaymentMethod
    {
        ICheckoutService _checkoutService;
        public PaymayaPaymentProcessor(ICheckoutService checkoutService)
        {
            _checkoutService = checkoutService;
        }

        public string Name => "Paymaya";

        public async Task<ProcessPaymentResult> ProcessPaymentAsync(ProcessPaymentRequest processPaymentRequest)
        {
            var response = await _checkoutService.CreateOrderAsync(processPaymentRequest.OrderId);
            var result = new ProcessPaymentResult
            {
                RedirectUrl = response.RedirectUrl,
                ThirdPartyPaymentId = response.CheckoutId
            };
            return result;
        }
    }
}
