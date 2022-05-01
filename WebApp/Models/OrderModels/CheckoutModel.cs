using Core.Domain.Orders;
using System.Collections.Generic;

namespace WebApplication3.Models.OrderModels
{
    public class CheckoutModel
    {
        public Order Order { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
