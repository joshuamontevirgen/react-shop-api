using Core.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Orders.Interfaces
{
    public interface IOrderItemService
    {
        OrderItem GetById(int id);
        OrderItem Add(OrderItem model);
        OrderItem Update(OrderItem model);
        IEnumerable<OrderItem> GetAll();
        IEnumerable<OrderItem> GetOrderItems(int orderId);
    }
}
