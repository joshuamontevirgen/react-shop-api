using AutoMapper;
using System.Collections.Generic;
using WebApplication3.Models.UserModels;
using WebApplication3.tempDB;
using System.Linq;

namespace WebApplication3.Services
{
    public class UserAddressService : IUserAddressService
    {
        private readonly IMapper _mapper;
        public UserAddressService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public void Add(UserAddressModel userAddress)
        {
            UserAddresses._userAddresses.Add(_mapper.Map<UserAddress>(userAddress));
        }

        public void Delete(int id)
        {
            UserAddresses._userAddresses.RemoveAll(s => s.Id == id);
        }

        public List<UserAddressModel> GetByUserid(int id)
        {
            return UserAddresses._userAddresses.Where(s => s.UserId == id).Select(s => _mapper.Map<UserAddressModel>(s)).ToList();
        }
    }
}
