using Core.Domain.Users;
using Core.Services.Users;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using UnitTester.DataGenerators.Interfaces;

namespace UnitTester
{
    public class UserAddressTests
    {
        IUserService _userService;
        IUserAddressService _userAddressService;
        IUserDataGenerator userDataGenerator;
        [SetUp]
        public void Setup()
        {
            var provider = new SetupDI();
            _userService = provider.GetService<IUserService>();
            _userAddressService = provider.GetService<IUserAddressService>();
            userDataGenerator = provider.GetService<IUserDataGenerator>();
        }



        [Test]
        public void AddAddress()
        {
            var user = userDataGenerator.AddUser();
            var address = new UserAddress
            {
                UserId = user.Id,
                Address = "address",
                City = "city",
                ZipCode = "123"
            };
            _userAddressService.Add(address);
            var addressGet = _userAddressService.GetById(address.Id);
            addressGet.Should().BeEquivalentTo(address);
        }


        [Test]
        public void GetUserAddresses()
        {
            var user1 = userDataGenerator.AddUser();
            var user2 = userDataGenerator.AddUser(); 
            _userAddressService.Add(new UserAddress
            {
                UserId = user1.Id,
                Address = "address",
                City = "city",
                ZipCode = "123"
            });
            _userAddressService.Add(new UserAddress
            {
                UserId = user1.Id,
                Address = "address",
                City = "city",
                ZipCode = "123"
            });
            _userAddressService.Add(new UserAddress
            {
                UserId = user2.Id,
                Address = "address",
                City = "city",
                ZipCode = "123"
            });
            var userAddresses = _userAddressService.GetUserAddresses(user1.Id);
            Assert.IsTrue(userAddresses.Count() == 2);
        }


    }
}
