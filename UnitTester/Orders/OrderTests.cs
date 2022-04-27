using Core.Services.Orders;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Core.Services.Orders.Interfaces;
using Core.Services.Items;
using UnitTester.Items;
using UnitTester.DataGenerators.Interfaces;

namespace UnitTester.Orders
{
    public class OrderTests
    {
        IOrderService _orderService;
        IOrderDataGenerator orderDataGenerator;
        IUserDataGenerator userDataGenerator;
        [SetUp]
        public void Setup()
        {
            var provider = new SetupDI();
            _orderService = provider.GetService<IOrderService>();
            userDataGenerator = provider.GetService<IUserDataGenerator>();
            orderDataGenerator = provider.GetService<IOrderDataGenerator>();
        }

        [Test]
        public void AddOrder()
        {
            var user = userDataGenerator.AddUser();
            var order = orderDataGenerator.AddOrder(user.Id);       

            var orderGet = _orderService.GetById(order.Id);
            orderGet.Should().BeEquivalentTo(order);
        }
    }
}
