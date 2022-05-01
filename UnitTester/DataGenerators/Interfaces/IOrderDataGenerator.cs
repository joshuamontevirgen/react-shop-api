using Core.Domain.Items;
using Core.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTester.DataGenerators.Interfaces
{
    public interface IOrderDataGenerator
    {
        Order AddOrder(int userId);

        OrderItem AddOrderItem(Order order, Item item, int quantity = 1);
    }
}
