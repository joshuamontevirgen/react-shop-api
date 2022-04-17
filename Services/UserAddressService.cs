using AutoMapper;
using System.Collections.Generic;
using WebApplication3.Models.UserModels;
using WebApplication3.tempDB;
using System.Linq;
using System;

namespace WebApplication3.Services
{
    public class UserAddressService : IUserAddressService
    {
        private readonly IMapper _mapper;
        public UserAddressService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public bool Add(int userId, UserAddressModel userAddress)
        {
            var newAddress = _mapper.Map<UserAddress>(userAddress);
            newAddress.Id = new Random().Next(1000000);
            newAddress.UserId = userId;
            UserAddresses._userAddresses.Add(newAddress);
            return true;
        }

        public void Delete(int id)
        {
            UserAddresses._userAddresses.RemoveAll(s => s.Id == id);
        }

        public List<UserAddressModel> GetByUserId(int id)
        {
            return UserAddresses._userAddresses.Where(s => s.UserId == id).Select(s => _mapper.Map<UserAddressModel>(s)).ToList();
        }
    }
}
