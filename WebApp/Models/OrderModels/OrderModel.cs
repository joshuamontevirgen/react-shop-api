using Core.Domain.Orders;
using Core.Domain.Users;

namespace WebApplication3.Models.OrderModels
{
    public class OrderModel : Order
    {      
        public string sPaymentStatus => PaymentStatus.ToString();
        public string sOrderStatus => OrderStatus.ToString();
        public UserAddress Address { get; set; }
    }
}
