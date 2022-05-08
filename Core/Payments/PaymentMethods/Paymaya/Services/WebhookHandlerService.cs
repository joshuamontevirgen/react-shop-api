using Core.Services.Orders.Interfaces;
using Core.Services.Payments.Interfaces;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Core.Payments.PaymentMethods.Paymaya.Models.Checkout;
using Core.Payments.PaymentMethods.Paymaya.Models.Webhooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Paymaya.Services
{
    internal class WebhookHandlerService : IWebhookHandlerService
    {
        IOrderProcessingService _orderProcessingService;
        IPaymentService _paymentService;
        public WebhookHandlerService(IOrderProcessingService orderProcessingService, IPaymentService paymentService)
        {
            _orderProcessingService = orderProcessingService;
            _paymentService = paymentService;
        }
        public async Task HandleWebhookAsync(HttpRequest request)
        {
            var rawRequestString = string.Empty;
            using (var streamReader = new StreamReader(request.Body))
                rawRequestString = await streamReader.ReadToEndAsync();

            var checkout = JsonConvert.DeserializeObject<CheckoutWebhookModel>(rawRequestString);
            var orderId = Convert.ToInt32(checkout.RequestReferenceNumber);


            switch (checkout.PaymentStatus)
            {
                case Webhook.PAYMENT_SUCCESS:
                    _paymentService.SetPaymentStatus(orderId, Core.Domain.Orders.PaymentStatus.Paid);
                    break;
                case Webhook.PAYMENT_FAILED:
                    _paymentService.SetPaymentStatus(orderId, Core.Domain.Orders.PaymentStatus.Failed);
                    break;
                case Webhook.PAYMENT_EXPIRED:
                    _paymentService.SetPaymentStatus(orderId, Core.Domain.Orders.PaymentStatus.Failed);
                    break;
                case Webhook.CHECKOUT_SUCCESS:
                    _paymentService.SetPaymentStatus(orderId, Core.Domain.Orders.PaymentStatus.Paid);
                    break;
                case Webhook.CHECKOUT_FAILURE:
                    _paymentService.SetPaymentStatus(orderId, Core.Domain.Orders.PaymentStatus.Failed);
                    break;
                case Webhook.CHECKOUT_DROPOUT:
                    _paymentService.SetPaymentStatus(orderId, Core.Domain.Orders.PaymentStatus.Failed);
                    break;
            }
            return;
        }
    }
}
