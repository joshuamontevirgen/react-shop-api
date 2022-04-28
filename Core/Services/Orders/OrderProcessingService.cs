﻿using Core.Services.Orders.Interfaces;
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
        public OrderProcessingService(IOrderService orderService, IOrderItemService orderItemService)
        {
            _orderService = orderService;
            _orderItemService = orderItemService;
        }
    }
}