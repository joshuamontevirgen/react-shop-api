using Core.Services.Orders.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTester.DataGenerators.Interfaces;
using FluentAssertions;
using Core.Domain.Orders;

namespace UnitTester.Orders
{
    internal class OrderProcessingTests
    {
        IOrderProcessingService _orderProcessingService;
        IOrderDataGenerator orderDataGenerator;
        IUserDataGenerator userDataGenerator;
        IItemDataGenerator itemDataGenerator;
        IOrderService _orderService;
        IOrderItemService _orderItemService;
        [SetUp]
        public void Setup()
        {
            var provider = new SetupDI();
            _orderService = provider.GetService<IOrderService>();
            _orderItemService = provider.GetService<IOrderItemService>();
            _orderProcessingService = provider.GetService<IOrderProcessingService>();
            userDataGenerator = provider.GetService<IUserDataGenerator>();
            orderDataGenerator = provider.GetService<IOrderDataGenerator>();
            itemDataGenerator = provider.GetService<IItemDataGenerator>();
        }


        [Test]
        public void PlaceOrder()
        {
            var item1 = itemDataGenerator.AddItem();
            var item2 = itemDataGenerator.AddItem();
            var user = userDataGenerator.AddUser();
            var address = userDataGenerator.AddAddress(user);
            var order = new Order
            {
                Date = DateTime.Now,
                OrderStatus = OrderStatus.Processing,
                PaymentStatus = PaymentStatus.Pending,
                UserId = user.Id,
                UserAddressId = address.Id,
            };
            var orderItem1 = new OrderItem
            {
                ItemId = item1.Id,
                Price = item1.Price,
                Quantity = 1
            };
            var orderItem2 = new OrderItem
            {
                ItemId = item2.Id,
                Price = item2.Price,
                Quantity = 1
            };


            _orderProcessingService.PlaceOrderAsync(order, new List<OrderItem> { orderItem1, orderItem2 });
            var orderItemGet = _orderItemService.GetOrderItems(order.Id);
            var orderGet = _orderService.GetById(order.Id);

            orderGet.Should().BeEquivalentTo(order);
            Assert.IsTrue(orderItemGet.Count() == 2);
        }
    }
}
