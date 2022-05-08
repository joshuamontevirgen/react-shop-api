using Core.Domain.Orders;
using Core.Payments.PaymentMethods.Paymaya.Models.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Payments.PaymentMethods.Paymaya.Services
{
    public interface ICheckoutService
    {
        Task<PaymayaCheckoutResponse> CreateOrderAsync(int orderId);
    }
}
