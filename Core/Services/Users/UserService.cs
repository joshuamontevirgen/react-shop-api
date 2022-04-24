using Core;
using Core.DB;
using Core.Domain.Services;
using Core.Domain.Services.Users;
using Core.Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Domain.Services.Users
{
    public class UserService
    {
        IRepository<User> _userRepository;
        public UserService(IRepository<User> userRepository)
        {
            //_userRepository = userRepository;

            DbContextOptions<ShopContext> options = new Microsoft.EntityFrameworkCore.DbContextOptionsBuilder<ShopContext>()
            .UseInMemoryDatabase(databaseName: "Test")
            .Options;

            _userRepository = new Repository<User>(new ShopContext(options));
        }


        public User GetById(int id)
        {
            return _userRepository.GetByID(id);
        }
        public void Add(User model)
        {
            _userRepository.Insert(model);
            _userRepository.Save();
        }
        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }


        public User Authenticate(string email, string password)
        {
            throw new NotImplementedException();
        }

 

        public User GetByEmail(string email)
        {
            throw new NotImplementedException();
        }


        public void Update(User model)
        {
            throw new NotImplementedException();
        }
    }
}
