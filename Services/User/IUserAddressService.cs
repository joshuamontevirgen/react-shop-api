using System.Collections.Generic;
using WebApplication3.Models.UserModels;

namespace WebApplication3.Services
{
    public interface IUserAddressService
    {
        public List<AddressModel> GetByUserId(int id);
        public bool Add(int userId, AddressModel userAddress);
        public void Delete(int id);
    }
}
