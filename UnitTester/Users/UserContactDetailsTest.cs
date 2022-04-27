using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Users;
using Core.Services.Users;
using FluentAssertions;
using NUnit.Framework;
using UnitTester.DataGenerators.Interfaces;

namespace UnitTester.Users
{
    public class UserContactDetailsTest
    {
        IUserService _userService;
        IUserContactDetailsService _contactDetailsService;
        IUserDataGenerator userDataGenerator;
        [SetUp]
        public void Setup()
        {
            var provider = new SetupDI();
            _userService = provider.GetService<IUserService>();
            _contactDetailsService = provider.GetService<IUserContactDetailsService>();
            userDataGenerator = provider.GetService<IUserDataGenerator>();
        }


        [Test]
        public void AddContactDetails()
        {
            var user = userDataGenerator.AddUser();
            var details = new UserContactDetails
            {
                UserId = user.Id,
                MobileNumber="0900000"
            };
            _contactDetailsService.Save(details);
            var detailsGet = _contactDetailsService.GetById(details.Id);
            detailsGet.Should().BeEquivalentTo(details);
        }

        [Test]
        public void UpdateContactDetails()
        {
            var user = userDataGenerator.AddUser();
            var details1 = new UserContactDetails
            {
                UserId = user.Id,
                MobileNumber = "1"
            };
            _contactDetailsService.Save(details1);

            var details2 = new UserContactDetails
            {
                UserId = user.Id,
                MobileNumber = "2"
            };
            _contactDetailsService.Save(details2);

            var detailsGet = _contactDetailsService.GetByUserId(user.Id);
            detailsGet.Should().BeEquivalentTo(details2);
        }

    }
}
