using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Payments.PaymentMethods.Paymaya
{
    public class Settings
    {
        public string SecretKey => "";
        public string ClientId => "";
        public string BaseUrl => "https://pg-sandbox.paymaya.com/";
        public bool UseSandbox => true;

        public string GetPublicAuthorizationString()
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(ClientId + ":"));
        }
        public string GetSecretAuthorizationString()
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(SecretKey + ":"));
        }
    }
}
