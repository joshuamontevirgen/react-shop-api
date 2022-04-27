using Core.Infrastructure;
using Core.Services.Users;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using FluentAssertions;


namespace UnitTester
{
    public class UserTests 
    {
        IUserService _userService;
        [SetUp]
        public void Setup()
        {
            var provider = new SetupDI();
            _userService = provider.GetService<IUserService>();
        }

        [Test]
        public void AddUser()
        {
            var user = new Core.Domain.Users.User
            {
                Email = "abc@abc.com",
                Password = "pass",
            };
            _userService.Add(user);

            var userGet = _userService.GetById(user.Id);
            userGet.Should().BeEquivalentTo(user);
        }

        [Test]
        public void AuthenticateUserCorrectPassword()
        {
            _userService.Add(new Core.Domain.Users.User
            {
                Email = "abc@abc.com1",
                Password = "pass",
            });

            var user = _userService.Authenticate("abc@abc.com1","pass");

            Assert.IsNotNull(user);
        }
        [Test]
        public void AuthenticateUserWrongPassword()
        {
            _userService.Add(new Core.Domain.Users.User
            {
                Email = "abc@abc.com2",
                Password = "pass",
            });

            var user = _userService.Authenticate("abc@abc.com2", "pass2");

            Assert.IsNull(user);
        }

        [Test]
        public void AuthenticateNotExistingUser()
        {
            _userService.Add(new Core.Domain.Users.User
            {
                Email = "abc@abc.com2",
                Password = "pass",
            });

            var user = _userService.Authenticate("!@$@#%%#^&abc@abc.com2", "pass2");

            Assert.IsNull(user);
        }
    }
}