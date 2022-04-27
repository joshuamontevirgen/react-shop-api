using Core;
using Core.DB;
using Core.Services;
using Core.Services.Users;
using Core.Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Repositories;

namespace Core.Services.Users
{
    public class UserService : IUserService
    {
        IRepository<User> _userRepository;
        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }


        public User GetById(int id)
        {
            return _userRepository.GetByID(id);
        }
        public User Add(User model)
        {
            return _userRepository.Insert(model);
        }
        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User Authenticate(string email, string password)
        {
            return _userRepository.Filter(filter: s => s.Email == email && s.Password == password).FirstOrDefault() ;
        }

        public User GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public User Update(User model)
        {
            throw new NotImplementedException();
        }
    }
}
