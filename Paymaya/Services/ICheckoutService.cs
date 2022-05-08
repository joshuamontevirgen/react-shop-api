﻿using Core.Domain.Orders;
using Paymaya.Models.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paymaya.Services
{
    public interface ICheckoutService
    {
        Task<PaymayaCheckoutResponse> CreateOrderAsync(int orderId);
    }
}
