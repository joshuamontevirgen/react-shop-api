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
    internal class OrderItemTests
    {
        IOrderService _orderService;
        IOrderItemService _orderItemService;
        IOrderDataGenerator orderDataGenerator;
        IUserDataGenerator userDataGenerator;
        IItemDataGenerator itemDataGenerator;
        [SetUp]
        public void Setup()
        {
            var provider = new SetupDI();
            _orderService = provider.GetService<IOrderService>();
            _orderItemService = provider.GetService<IOrderItemService>();
            userDataGenerator = provider.GetService<IUserDataGenerator>();
            orderDataGenerator = provider.GetService<IOrderDataGenerator>();
            itemDataGenerator = provider.GetService<IItemDataGenerator>();
        }

        [Test]
        public void AddOrderItem()
        {
            var item1 = itemDataGenerator.AddItem();
            var user = userDataGenerator.AddUser();

            var order = orderDataGenerator.AddOrder(user.Id);
            var orderItem = new OrderItem
            {
                ItemId = item1.Id,
                OrderId = order.Id,
                Price = item1.Price,
                Quantity = 1
            };
            _orderItemService.Add(orderItem);

            var orderItemGet = _orderItemService.GetById(orderItem.Id);
            orderItemGet.Should().BeEquivalentTo(orderItem);
        }


        [Test]
        public void GetOrderItems()
        {
            var item1 = itemDataGenerator.AddItem();
            var item2 = itemDataGenerator.AddItem();
            var user = userDataGenerator.AddUser();

            var order1 = orderDataGenerator.AddOrder(user.Id);
            var order1Item1 = orderDataGenerator.AddOrderItem(order1.Id, item1);
            var order1Item2 = orderDataGenerator.AddOrderItem(order1.Id, item2);

            var order2 = orderDataGenerator.AddOrder(user.Id);
            var order2Item1 = orderDataGenerator.AddOrderItem(order2.Id, item1);


            var orderitems = _orderItemService.GetOrderItems(order1.Id);
            Assert.IsTrue(orderitems.Count() == 2);
        }
    }
}
