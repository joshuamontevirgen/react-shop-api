using Core.Domain.Orders;
using Core.Domain.Users;
using System.Collections.Generic;

namespace WebApplication3.Models.OrderModels
{
    public class OrderModel : Order
    {      
        public string sPaymentStatus => PaymentStatus.ToString();
        public string sOrderStatus => OrderStatus.ToString();
        public UserAddress Address { get; set; }
        public string sDate => Date.ToString("MM/dd/yyyy hh:mm tt");
        public List<OrderItemModel> Items { get; set; }
    }
}
