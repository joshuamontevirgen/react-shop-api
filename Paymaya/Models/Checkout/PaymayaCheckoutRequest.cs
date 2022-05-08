using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paymaya.Models.Checkout
{
    //https://hackmd.io/@paymaya-pg/Checkout
    public class PaymayaCheckoutRequest
    {
        #region Properties

        [JsonProperty(PropertyName = "totalAmount")]
        public TotalAmount TotalAmount { get; set; }

        [JsonProperty(PropertyName = "buyer")]
        public Buyer Buyer { get; set; }

        [JsonProperty(PropertyName = "items")]
        public List<Item> Items { get; set; }

        [JsonProperty(PropertyName = "redirectUrl")]
        public RedirectUrl RedirectUrl { get; set; }

        [JsonProperty(PropertyName = "requestReferenceNumber")]
        public string RequestReferenceNumber { get; set; }

        [JsonProperty(PropertyName = "metadata")]
        public dynamic Metadata { get; set; }
        #endregion
    }
    public class TotalAmount
    {
        public TotalAmount()
        {
            Details = new AmountDetails();
        }
        [JsonProperty(PropertyName = "value")]
        public decimal Value { get; set; }

        [JsonProperty(PropertyName = "currency")]
        public string Currency => "PHP";

        [JsonProperty(PropertyName = "details")]
        public AmountDetails Details { get; set; }

    }

    public class Buyer
    {
        public Buyer()
        {
            Contact = new Contact();
            ShippingAddress = new ShippingAddress();
            BillingAddress = new BillingAddress();
        }

        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "middleName")]
        public string MiddleName { get; set; }

        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

        /// <summary>
        /// yyyy-dd-mm
        /// </summary>
        [JsonProperty(PropertyName = "birthDay")]
        public string BirthDay { get; set; }

        /// <summary>
        /// yyyy-dd-mm
        /// </summary>
        [JsonProperty(PropertyName = "customerSince")]
        public string CustomerSince { get; set; }

        /// <summary>
        /// M / F
        /// </summary>
        [JsonProperty(PropertyName = "sex")]
        public string Sex { get; set; }

        [JsonProperty(PropertyName = "contact")]
        public Contact Contact { get; set; }

        [JsonProperty(PropertyName = "shippingAddress")]
        public ShippingAddress ShippingAddress { get; set; }

        [JsonProperty(PropertyName = "billingAddress")]
        public BillingAddress BillingAddress { get; set; }
    }

    public class Contact
    {
        [JsonProperty(PropertyName = "phone")]
        public string Phone { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
    }
    public class ShippingAddress
    {
        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "middleName")]
        public string MiddleName { get; set; }

        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "phone")]
        public string Phone { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "line1")]
        public string Line1 { get; set; }

        [JsonProperty(PropertyName = "line2")]
        public string Line2 { get; set; }

        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }

        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }

        [JsonProperty(PropertyName = "zipCode")]
        public string ZipCode { get; set; }

        [JsonProperty(PropertyName = "countryCode")]
        public string CountryCode { get; set; }

        [JsonProperty(PropertyName = "shippingType")]
        public string ShippingType { get; set; }

    }
    public enum ShippingType
    {
        ST,//standard
        SD//sameday
    }
    public class BillingAddress
    {
        [JsonProperty(PropertyName = "line1")]
        public string Line1 { get; set; }

        [JsonProperty(PropertyName = "line2")]
        public string Line2 { get; set; }

        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }

        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }

        [JsonProperty(PropertyName = "zipCode")]
        public string ZipCode { get; set; }

        [JsonProperty(PropertyName = "countryCode")]
        public string CountryCode { get; set; }
    }
    public class Item
    {
        public Item()
        {
            Amount = new Amount();
            TotalAmount = new Amount();
        }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "quantity")]
        public decimal Quantity { get; set; }

        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "amount")]
        public Amount Amount { get; set; }

        [JsonProperty(PropertyName = "totalAmount")]
        public Amount TotalAmount { get; set; }
    }
    public class Amount
    {
        public Amount()
        {
            Details = new AmountDetails();
        }
        [JsonProperty(PropertyName = "value")]
        public decimal Value { get; set; }

        [JsonProperty(PropertyName = "details")]
        public AmountDetails Details { get; set; }
    }
    public class AmountDetails
    {
        [JsonProperty(PropertyName = "discount")]
        public decimal Discount { get; set; }

        [JsonProperty(PropertyName = "serviceCharge")]
        public decimal ServiceCharge { get; set; }

        [JsonProperty(PropertyName = "shippingFee")]
        public decimal ShippingFee { get; set; }

        [JsonProperty(PropertyName = "tax")]
        public decimal Tax { get; set; }

        [JsonProperty(PropertyName = "subTotal")]
        public decimal Subtotal { get; set; }
    }



}
