using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Payments.PaymentMethods.Paymaya
{
    public class Settings
    {
        //https://hackmd.io/@paymaya-pg/Checkout#Sandbox-Test-Credentials
        public string SecretKey => "sk-VGDKY3P90NYZZ0kSWqBFaD1NTIXQCxtdS7SbQXvcA4g";
        public string ClientId => "pk-yaj6GVzYkce52R193RIWpuRR5tTZKqzBWsUeCkP9EAf";
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
