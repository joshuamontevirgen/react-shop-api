using Core.Domain.Items;
using Core.Domain.Orders;
using Core.Services.Orders;
using Core.Services.Orders.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTester.DataGenerators.Interfaces;

namespace UnitTester.DataGenerators
{
    public class OrderDataGenerator : IOrderDataGenerator
    {
        IOrderService _orderService;
        IOrderItemService _orderItemService;
        public OrderDataGenerator(IOrderService orderService, IOrderItemService orderItemService)
        {
            _orderService = orderService;
            _orderItemService = orderItemService;
        }

        public Order AddOrder(int userId)
        {
            var order = new Order
            {
                Date = DateTime.Now,
                UserId = userId,
                OrderStatus = OrderStatus.Processing,
                PaymentStatus = PaymentStatus.Pending
            };
            return _orderService.Add(order);
        }

        public OrderItem AddOrderItem(int orderId, Item item, int quantity = 1)
        {
            var order = new OrderItem
            {
                ItemId = item.Id,
                OrderId = orderId,
                Price = item.Price,
                Quantity = quantity,
            };
            return _orderItemService.Add(order);
        }
    }
}
