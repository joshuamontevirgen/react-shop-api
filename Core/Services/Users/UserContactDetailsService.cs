using Core.Domain.Users;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Users
{
    public class UserContactDetailsService : IUserContactDetailsService
    {
        IRepository<UserContactDetails> _repository;
        public UserContactDetailsService(IRepository<UserContactDetails> repository)
        {
            _repository = repository;
        }
        public UserContactDetails Add(UserContactDetails model)
        {
             return _repository.Insert(model);
        }

        public UserContactDetails Update(UserContactDetails model)
        {
            return _repository.Update(model);
        }

        public UserContactDetails Save(UserContactDetails model)
        {
            var existing = _repository.Filter(filter: s => s.UserId == model.UserId).FirstOrDefault();
            if(existing != null)
            {
                model.Id = existing.Id;
                return _repository.Update(model);
            }
            else
            {
                return _repository.Insert(model);
            }
        }


        public IEnumerable<UserContactDetails> GetAll()
        {
            return _repository.GetAll();
        }

        public UserContactDetails GetById(int id)
        {
            return  _repository.GetByID(id);
        }

        public UserContactDetails GetByUserId(int userId)
        {
            return _repository.Filter(filter: s => s.UserId == userId).FirstOrDefault();
        }
    }
}
