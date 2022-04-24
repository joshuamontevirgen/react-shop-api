using Core.Domain.Services.Users;
using NUnit.Framework;

namespace UnitTester
{
    public class UserTests
    {
        UserService _userService;
        [SetUp]
        public void Setup()
        {
            _userService = new UserService(null);
        }

        [Test]
        public void AddUser()
        {
            _userService.Add(new Core.Domain.Users.User
            {
                Email = "abc@abc.com",
                Password = "pass",
            });

            var user = _userService.GetById(1);

            Assert.IsNotNull(user);
        }
    }
}