using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paymaya.Models.Webhooks
{
    public class Webhook
    {
        public const string CHECKOUT_SUCCESS = "CHECKOUT_SUCCESS";
        public const string CHECKOUT_FAILURE = "CHECKOUT_FAILURE";
        public const string CHECKOUT_DROPOUT = "CHECKOUT_DROPOUT";

        public const string PAYMENT_SUCCESS = "PAYMENT_SUCCESS";
        public const string PAYMENT_FAILED = "PAYMENT_FAILED";
        public const string PAYMENT_EXPIRED = "PAYMENT_EXPIRED";
        public static List<string> EventNames => new()
        {
            CHECKOUT_SUCCESS,
            CHECKOUT_FAILURE,
            CHECKOUT_DROPOUT,
            PAYMENT_SUCCESS,
            PAYMENT_FAILED,
            PAYMENT_EXPIRED
        };

        public Webhook()
        {
            Name = string.Empty;
            CallbackUrl = string.Empty;
            Id = string.Empty;
            CreatedAt = string.Empty;
            UpdatedAt = string.Empty;
        }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "callbackUrl")]
        public string CallbackUrl { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "createdAt")]
        public string CreatedAt { get; set; }

        [JsonProperty(PropertyName = "updatedAt")]
        public string UpdatedAt { get; set; }

    }
}
