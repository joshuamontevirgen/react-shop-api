using Core.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Users
{
    public interface IUserAddressService
    {
        UserAddress GetById(int id);
        UserAddress Add(UserAddress model);
        IEnumerable<UserAddress> GetUserAddresses(int userid);
        IEnumerable<UserAddress> GetAll();
    }
}
