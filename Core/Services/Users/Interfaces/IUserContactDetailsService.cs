using Core.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Users
{
    public interface IUserContactDetailsService
    {
        UserContactDetails GetById(int id);
        UserContactDetails GetByUserId(int userId);
        UserContactDetails Save(UserContactDetails model);
        IEnumerable<UserContactDetails> GetAll();
    }
}
