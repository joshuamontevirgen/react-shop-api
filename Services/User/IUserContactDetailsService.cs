using WebApplication3.Models.UserModels;

namespace WebApplication3.Services
{
    public interface IUserContactDetailsService
    {
        public bool Save(int userId, ContactDetailsModel mobileNumber);
        public ContactDetailsModel Get(int userId);
    }
}
