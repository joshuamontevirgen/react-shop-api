﻿using Core.Domain.Orders;
using Paymaya.Client;
using Paymaya.Models.Checkout;
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

namespace Paymaya.Services
{
    public class CheckoutService : ICheckoutService
    {
        Settings _settings;
        IItemService _itemService;
        IOrderItemService _orderItemService;
        public CheckoutService(Settings settings, IItemService itemService, IOrderItemService orderItemService)
        {
            _settings = settings;
            _itemService = itemService;
            _orderItemService = orderItemService;
        }

        public async Task<CheckoutResponse> CreateOrder(Order order)
        {
            var orderItems = _orderItemService.GetOrderItems(order.Id);


            var checkoutRequest = new CheckoutRequest();
            checkoutRequest.RequestReferenceNumber = order.Id.ToString();

            checkoutRequest.Buyer = new Buyer
            {
                FirstName = "",
                LastName = "",
                Contact = new Contact
                {
                    Email = "",
                    Phone = "",
                },
                BillingAddress = new BillingAddress
                {
                    Line1 = "",
                    Line2 = "",
                    City = "",
                    ZipCode = "",
                    State = "",
                    CountryCode = "",
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
           

            using(var client = new PublicClient(_settings))
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
                var result = JsonConvert.DeserializeObject<CheckoutResponse>(responseContent);
                return result;
            }
        }

    }
}
