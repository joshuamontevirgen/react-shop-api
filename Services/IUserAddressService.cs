using System.Collections.Generic;
using WebApplication3.Models.UserModels;

namespace WebApplication3.Services
{
    public interface IUserAddressService
    {
        public List<UserAddressModel> GetByUserid(int id);
        public void Add(UserAddressModel userAddress);
        public void Delete(int id);
    }
}
