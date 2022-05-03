using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Paymaya.Client
{
    public class PublicClient : PaymayaClient
    {
        public PublicClient(Settings settings) : base(settings)
        {
            DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", settings.GetPublicAuthorizationString());
        }
    }
}
