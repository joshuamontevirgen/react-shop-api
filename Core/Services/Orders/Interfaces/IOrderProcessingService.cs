using Core.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Orders.Interfaces
{
    public interface IOrderProcessingService
    {
        Order PlaceOrder(Order order, List<OrderItem> items);
    }
}
