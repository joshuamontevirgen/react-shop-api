using Core.Domain.Orders;
using Core.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Payments.Interfaces
{
    public interface IPaymentService
    {
        Task<ProcessPaymentResult> ProcessPaymentAsync(ProcessPaymentRequest processPaymentRequest);
        void SetPaymentStatus(int orderId, PaymentStatus status);
    }
}
