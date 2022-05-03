using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Paymaya.Models.Checkout;
using Paymaya.Models.Webhooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paymaya.Services
{
    internal class WebhookHandlerService : IWebhookHandlerService
    {
        public async Task HandleWebhookAsync(HttpRequest request)
        {
            var rawRequestString = string.Empty;
            using (var streamReader = new StreamReader(request.Body))
                rawRequestString = await streamReader.ReadToEndAsync();

            var checkout = JsonConvert.DeserializeObject<CheckoutWebhookModel>(rawRequestString);
            var orderId = checkout.RequestReferenceNumber;

            switch (checkout.PaymentStatus)
            {
                case Webhook.PAYMENT_SUCCESS:
                    break;
                case Webhook.PAYMENT_FAILED:
                    break;
                case Webhook.PAYMENT_EXPIRED:
                    break;
                case Webhook.CHECKOUT_SUCCESS:
                    break;
                case Webhook.CHECKOUT_FAILURE:
                    break;
                case Webhook.CHECKOUT_DROPOUT:
                    break;
            }
            return;
        }
    }
}
