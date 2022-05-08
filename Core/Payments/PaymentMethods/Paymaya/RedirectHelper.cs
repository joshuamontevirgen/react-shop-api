using Core.Payments.PaymentMethods.Paymaya.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Payments.PaymentMethods.Paymaya
{
    public class RedirectHelper
    {
        //id = RequestReferenceNumber
        public static RedirectUrl GetRedirectUrl(string id)
        {
            var domain = "";
            return new RedirectUrl
            {
                Success = $"{domain}/order/{id}",
                Failure = $"{domain}/order/{id}",
                Cancel = $"{domain}/order/{id}"
            };
        }
    }
}
