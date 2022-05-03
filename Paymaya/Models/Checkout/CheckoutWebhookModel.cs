using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paymaya.Models.Checkout
{
    public class CheckoutWebhookModel : CheckoutRequest
    {
        public CheckoutWebhookModel() : base()
        {
            Merchant = new Merchant();
        }
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "createdAt")]
        public string CreatedAt { get; set; }

        [JsonProperty(PropertyName = "updatedAt")]
        public string UpdatedAt { get; set; }

        [JsonProperty(PropertyName = "expiredAt")]
        public string ExpiredAt { get; set; }

        [JsonProperty(PropertyName = "paymentScheme")]
        public string PaymentScheme { get; set; }

        [JsonProperty(PropertyName = "expressCheckout")]
        public string ExpressCheckout { get; set; }

        [JsonProperty(PropertyName = "refundedAmount")]
        public decimal RefundedAmount { get; set; }

        [JsonProperty(PropertyName = "canPayPal")]
        public bool CanPayPal { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "merchant")]
        public Merchant Merchant { get; set; }

        [JsonProperty(PropertyName = "transactionReferenceNumber")]
        public string TransactionReferenceNumber { get; set; }

        [JsonProperty(PropertyName = "paymentStatus")]
        public string PaymentStatus { get; set; }

    }

    public class PaymentDetails
    {
        public PaymentDetails()
        {
            Responses = new Responses();
        }
        [JsonProperty(PropertyName = "responses")]
        public Responses Responses { get; set; }

        [JsonProperty(PropertyName = "paymentAt")]
        public string PaymentAt { get; set; }

        [JsonProperty(PropertyName = "3ds")]
        public bool Is3ds { get; set; }
    }
    public class Responses
    {
        public Responses()
        {
            Data = new Data();
            Links = new Links();

        }
        [JsonProperty(PropertyName = "data")]
        public Data Data { get; set; }

        [JsonProperty(PropertyName = "links")]
        public Links Links { get; set; }

        [JsonProperty(PropertyName = "metadata")]
        public dynamic Metadata { get; set; }
    }
    public class Data
    {
        public Data()
        {
            Efs = new efs();
        }
        [JsonProperty(PropertyName = "efs")]
        public efs Efs { get; set; }
    }
    public class efs
    {
        [JsonProperty(PropertyName = "financialNetworkCode")]
        public string FinancialNetworkCode { get; set; }

        [JsonProperty(PropertyName = "acquirerResponseCode")]
        public string AcquirerResponseCode { get; set; }

        [JsonProperty(PropertyName = "transactionNumber")]
        public string TransactionNumber { get; set; }

        [JsonProperty(PropertyName = "cardType")]
        public string CardType { get; set; }

        [JsonProperty(PropertyName = "transactionIdentifier")]
        public string TransactionIdentifier { get; set; }

        [JsonProperty(PropertyName = "marketSpecificData")]
        public string MarketSpecificData { get; set; }

        [JsonProperty(PropertyName = "commercialCardIndicator")]
        public string CommercialCardIndicator { get; set; }

        [JsonProperty(PropertyName = "cardLevelIndicator")]
        public string CardLevelIndicator { get; set; }

        [JsonProperty(PropertyName = "maskedResponseMetadataCardNumber")]
        public string MaskedResponseMetadataCardNumber { get; set; }

        [JsonProperty(PropertyName = "riskCategory")]
        public string RiskCategory { get; set; }

        [JsonProperty(PropertyName = "returnACI")]
        public string ReturnACI { get; set; }

        [JsonProperty(PropertyName = "authorizeId")]
        public string AuthorizeId { get; set; }

        [JsonProperty(PropertyName = "riskScore")]
        public decimal RiskScore { get; set; }

        [JsonProperty(PropertyName = "commercialCard")]
        public string CommercialCard { get; set; }

        [JsonProperty(PropertyName = "batchNumber")]
        public string BatchNumber { get; set; }

        [JsonProperty(PropertyName = "receipt_number")]
        public string ReceiptNumber { get; set; }
    }
    public class Links
    {
        [JsonProperty(PropertyName = "rel")]
        public string Rel { get; set; }
    }

    public class Merchant
    {
        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }


        [JsonProperty(PropertyName = "locale")]
        public string Locale { get; set; }

        [JsonProperty(PropertyName = "homepageUrl")]
        public string HomepageUrl { get; set; }

        [JsonProperty(PropertyName = "isEmailToMerchantEnabled")]
        public string IsEmailToMerchantEnabled { get; set; }

        [JsonProperty(PropertyName = "isEmailToBuyerEnabled")]
        public string IsEmailToBuyerEnabled { get; set; }

        [JsonProperty(PropertyName = "isPaymentFacilitator")]
        public string IsPaymentFacilitator { get; set; }

        [JsonProperty(PropertyName = "isPageCustomized")]
        public string IsPageCustomized { get; set; }

        [JsonProperty(PropertyName = "supportedSchemes")]
        public List<string> SupportedSchemes { get; set; }

        [JsonProperty(PropertyName = "canPayPal")]
        public string CanPayPal { get; set; }

        [JsonProperty(PropertyName = "payPalEmail")]
        public string PayPalEmail { get; set; }

        [JsonProperty(PropertyName = "payPalWebExperienceId")]
        public string PayPalWebExperienceId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }


    }
}
