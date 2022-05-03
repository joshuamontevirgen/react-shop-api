using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paymaya.Models
{
    public class RedirectUrl
    {
        [JsonProperty(PropertyName = "success")]
        public string Success { get; set; }

        [JsonProperty(PropertyName = "failure")]
        public string Failure { get; set; }

        [JsonProperty(PropertyName = "cancel")]
        public string Cancel { get; set; }
    }
}
