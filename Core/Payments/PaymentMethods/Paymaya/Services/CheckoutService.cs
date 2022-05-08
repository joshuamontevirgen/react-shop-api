using Core.Domain.Orders;
using Core.Payments.PaymentMethods.Paymaya.Client;
using Core.Payments.PaymentMethods.Paymaya.Models.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Core.Services.Items;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Core.Services.Orders.Interfaces;
using Core.Services.Users;
using System.Net.Http;

namespace Core.Payments.PaymentMethods.Paymaya.Services
{
    public class CheckoutService : ICheckoutService
    {
        IItemService _itemService;
        IOrderService _orderService;
        IOrderItemService _orderItemService;
        IUserService _userService;
        IUserContactDetailsService _userContactDetailsService;
        IUserAddressService _userAddressService;
        public CheckoutService(
            IItemService itemService,
            IOrderService orderService,
            IOrderItemService orderItemService,
            IUserService userService, 
            IUserContactDetailsService contactDetailsService,
            IUserAddressService userAddressService)
        {
            _itemService = itemService;
            _orderService = orderService;
            _orderItemService = orderItemService;
            _userService = userService;
            _userContactDetailsService = contactDetailsService;
            _userAddressService = userAddressService;
        }

        public async Task<PaymayaCheckoutResponse> CreateOrderAsync(int orderId)
        {
            var order = _orderService.GetById(orderId);
            var orderItems = _orderItemService.GetOrderItems(order.Id);
            var user = _userService.GetById(order.UserId);
            var userAddress = _userAddressService.GetById(order.UserAddressId);
            var contact = _userContactDetailsService.GetByUserId(order.UserId);

            var checkoutRequest = new PaymayaCheckoutRequest();
            checkoutRequest.RequestReferenceNumber = order.Id.ToString();

            checkoutRequest.Buyer = new Buyer
            {
                FirstName = "",
                LastName = "",
                Contact = new Contact
                {
                    Email = user.Email,
                    Phone = "",
                },
                BillingAddress = new BillingAddress
                {
                    Line1 = userAddress.Address,
                    Line2 = "",
                    City = userAddress.City,
                    ZipCode = userAddress.ZipCode,
                    State = "",
                    CountryCode = "PH",
                }
            };

            checkoutRequest.Buyer.ShippingAddress = new ShippingAddress
            {
                FirstName = "",
                LastName = "",
                Email = "",
                Phone = "",
                Line1 = "",
                Line2 = "",
                City = "",
                ZipCode = "",
                State = "",
                ShippingType = ShippingType.SD.ToString(),
                CountryCode = "",
            };




            checkoutRequest.Items = orderItems.Select(orderItem =>
            {
                var item = _itemService.GetById(orderItem.ItemId);
                return new Item
                {
                    Name = item.Name,
                    Description = "",
                    Quantity = orderItem.Quantity,
                    Amount = new Amount
                    {
                        Value = orderItem.Price,
                        Details = new AmountDetails
                        {
                            Discount = 0,
                            Subtotal = orderItem.Price
                        },
                    },
                    TotalAmount = new Amount
                    {
                        Value = Math.Round(orderItem.Price * orderItem.Quantity, 2),
                        Details = new AmountDetails
                        {
                            Discount = 0,
                            Subtotal = Math.Round(orderItem.Price * orderItem.Quantity, 2)
                        },
                    }
                };               
            }).ToList();

            var total = orderItems.Sum(item => item.Price * item.Quantity);
            checkoutRequest.TotalAmount = new TotalAmount
            {
                Value = Math.Round(total, 2),
                Details = new AmountDetails
                {
                    Discount = 0,
                    Tax = 0,
                    ShippingFee = 0,
                }
            };


            checkoutRequest.RedirectUrl = RedirectHelper.GetRedirectUrl(checkoutRequest.RequestReferenceNumber);
            var requestContent = JsonConvert.SerializeObject(checkoutRequest);
           

           // using(var client = new PublicClient(_settings))
            using (var client = new PublicClient(new Settings()))
            {
                var address = "checkout/v1/checkouts";
                var request = new HttpRequestMessage()
                {
                    Content = new StringContent(requestContent, Encoding.UTF8, "application/json"),
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(client.BaseAddress, address)
                };

                var response = await client.SendAsync(request);
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<PaymayaCheckoutResponse>(responseContent);
                return result;
            }
        }

    }
}
