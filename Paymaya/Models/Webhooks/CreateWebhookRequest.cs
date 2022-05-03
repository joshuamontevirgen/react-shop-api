using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paymaya.Models.Webhooks
{
    internal class CreateWebhookRequest
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "callbackUrl")]
        public string CallbackUrl { get; set; }
    }
}
