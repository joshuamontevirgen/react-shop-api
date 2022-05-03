using Core.Domain.Orders;
using System.Collections.Generic;
using WebApplication3.Models.OrderModels;

namespace WebApplication3.Models.Factories
{
    public interface IOrderModelFactory
    {        
        List<OrderModel> ToModel(List<Order> orders);
        OrderModel ToModel(Order order);
    }
}
