using Core.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Users
{
    public interface IUserService  
    {
        User GetById(int id);
        User Add(User model);
        User Update(User model);
        IEnumerable<User> GetAll();
        User Authenticate(string email, string password);

        User GetByEmail(string email);

 
    }
}
