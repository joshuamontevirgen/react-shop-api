using Core.Domain.Users;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Users
{
    public class UserAddressService : IUserAddressService
    {
        IRepository<UserAddress> _userAddressRepository;
        public UserAddressService(IRepository<UserAddress> userAddressRepository)
        {
            _userAddressRepository = userAddressRepository;
        }

        public UserAddress Add(UserAddress model)
        {
            return _userAddressRepository.Insert(model);
        }

        public IEnumerable<UserAddress> GetAll()
        {
            return _userAddressRepository.GetAll();
        }

        public IEnumerable<UserAddress> GetUserAddresses(int userid)
        {
            return _userAddressRepository.Filter(filter: s => s.UserId == userid);
        }

        public UserAddress GetById(int id)
        {
            return _userAddressRepository.GetByID(id);
        }
    }
}
