using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;
using WebApplication3.Models.UserModels;
using WebApplication3.tempDB;

namespace WebApplication3.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;

        public UserService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ReturnValue Add(RegisterUserModel model)
        {
            if(Users._users.Any(s => s.Email == model.Email))
            {
                return new ReturnValue
                {
                    Success = false,
                    Message = "Email is already taken"
                };
            }

            Users._users.Add(new User
            {
                Email = model.Email,
                Password = model.Password,
                Id = new Random().Next(10000)
            }) ;
            return new ReturnValue
            {
                Success = true,
                Message = "Registration success"
            };
        }
        public void Update(UserModel model)
        {
            var user =  Users._users.FirstOrDefault(s => s.Id == model.Id);
        }

        public UserModel Authenticate(string email, string password)
        {
            return _mapper.Map<UserModel>( Users._users.FirstOrDefault(s => s.Email == email && s.Password == password));
        }

        public IEnumerable<UserModel> GetAll()
        {
            return  Users._users.ToList().Select(u => _mapper.Map<UserModel>(u));
        }

        public UserModel GetByEmail(string email)
        {
            return _mapper.Map<UserModel>( Users._users.FirstOrDefault(s => s.Email == email));
        }

        public UserModel GetById(int id)
        {
            return _mapper.Map<UserModel>( Users._users.FirstOrDefault(s => s.Id == id));
        }
    }
}
