using Core.Domain.Users;
using Core.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTester.DataGenerators.Interfaces;

namespace UnitTester.Users
{
    public class UserDataGenerator : IUserDataGenerator
    {
        IUserService _userService;
        IUserAddressService _userAddressService;
        public UserDataGenerator(IUserService userService, IUserAddressService userAddressService)
        {
            _userService = userService;
            _userAddressService = userAddressService;
        }
        public User AddUser()
        {
            return _userService.Add(new Core.Domain.Users.User
            {
                Email = $"{Guid.NewGuid().ToString()}@abc.com",
                Password = "pass",
            });
        }
        public UserAddress AddAddress(User user)
        {
            var address = new UserAddress
            {
                UserId = user.Id,
                Address = $"{Guid.NewGuid()}",
                City = $"{Guid.NewGuid()}",
                ZipCode = $"{Guid.NewGuid()}"
            };
            return _userAddressService.Add(address);
        }
    }
}
