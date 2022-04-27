using Core.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Orders.Interfaces
{
    public interface IOrderService
    {
        Order GetById(int id);
        Order Add(Order model);
        Order Update(Order model);
        IEnumerable<Order> GetAll();
        IEnumerable<Order> GetUserOrders(int userId);
    }
}
