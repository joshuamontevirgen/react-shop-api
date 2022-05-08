using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Core.Payments.PaymentMethods.Paymaya.Client
{
    public abstract class PaymayaClient : HttpClient
    {
        public PaymayaClient(Settings settings)
        {        
            DefaultRequestHeaders.Accept.Clear();
            BaseAddress = new Uri(settings.BaseUrl);
        }
    }
}
