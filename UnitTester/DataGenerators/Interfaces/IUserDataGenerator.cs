using Core.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTester.DataGenerators.Interfaces
{
    public interface IUserDataGenerator 
    {
        User AddUser();
        UserAddress AddAddress(User user);
    }
}
