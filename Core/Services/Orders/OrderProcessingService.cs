﻿using Core.Domain.Orders;
using Core.Services.Orders.Interfaces;
using Core.Services.Payments.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Orders
{
    public class OrderProcessingService : IOrderProcessingService
    {
        IOrderService _orderService;
        IOrderItemService _orderItemService;
        IPaymentService _paymentService;
        public OrderProcessingService(IOrderService orderService, IOrderItemService orderItemService, IPaymentService paymentService)
        {
            _orderService = orderService;
            _orderItemService = orderItemService;
            _paymentService = paymentService;
         }

        public async Task<PlaceOrderResult> PlaceOrderAsync(Order order, List<OrderItem> items)
        {
            _orderService.Add(order);
            _orderItemService.Add(order, items);
            var processPaymentResult = await _paymentService.ProcessPaymentAsync(new Core.Payments.ProcessPaymentRequest
            {
                OrderId = order.Id,
                UserId = order.UserId,
                PaymentMethod = order.PaymentMethod
            });
            return new PlaceOrderResult
            {
                Order = order,
                PaymentProcess = processPaymentResult
            };
        }


    }
}

