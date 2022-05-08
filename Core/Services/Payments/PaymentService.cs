using Core.Domain.Orders;
using Core.Payments;
using Core.Services.Orders.Interfaces;
using Core.Services.Payments.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Payments
{
    public class PaymentService : IPaymentService
    {
        IOrderService _orderService;
        IPaymentMethodSelector _paymentMethodSelector;
        public PaymentService(IOrderService orderService, IPaymentMethodSelector paymentMethodSelector)
        {
            _orderService = orderService;
            _paymentMethodSelector = paymentMethodSelector;
        }

        public async Task<ProcessPaymentResult> ProcessPaymentAsync(ProcessPaymentRequest processPaymentRequest)
        {
            var paymentMethod = _paymentMethodSelector.SelectPaymentMethod("");
            return await paymentMethod.ProcessPaymentAsync(processPaymentRequest);
        }

        public void SetPaymentStatus(int orderId, PaymentStatus status)
        {
            var order = _orderService.GetById(orderId);
            order.PaymentStatus = status;
            _orderService.Update(order);
        }
    }
}
