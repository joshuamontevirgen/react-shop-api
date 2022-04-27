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
        public UserDataGenerator(IUserService userService)
        {
            _userService = userService;
        }
        public User AddUser()
        {
            return _userService.Add(new Core.Domain.Users.User
            {
                Email = $"{Guid.NewGuid().ToString()}@abc.com",
                Password = "pass",
            });
        }
    }
}
