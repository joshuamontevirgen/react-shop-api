using System.Collections.Generic;
using WebApplication3.Models.UserModels;

namespace WebApplication3.Services
{
    public interface IUserAddressService
    {
        public List<UserAddressModel> GetByUserId(int id);
        public bool Add(int userId, UserAddressModel userAddress);
        public void Delete(int id);
    }
}
