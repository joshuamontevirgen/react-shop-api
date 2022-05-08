using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Payments.PaymentMethods.Paymaya.Models.Checkout
{
    public class PaymayaCheckoutResponse
    {
        [JsonProperty(PropertyName = "checkoutId")]
        public string CheckoutId { get; set; }

        [JsonProperty(PropertyName = "redirectUrl")]
        public string RedirectUrl { get; set; }
    }
}
