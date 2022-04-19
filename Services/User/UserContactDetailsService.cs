using WebApplication3.tempDB;
using System.Linq;
using WebApplication3.Models.UserModels;
using AutoMapper;
using System;

namespace WebApplication3.Services
{
    public class UserContactDetailsService : IUserContactDetailsService
    {
        private readonly IMapper _mapper;

        public UserContactDetailsService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public ContactDetailsModel Get(int userId)
        {
            return _mapper.Map<ContactDetailsModel>(UserContactDetailsList._userContactDetails.FirstOrDefault(s => s.UserId == userId));
        }

        public bool Save(int userId, ContactDetailsModel model)
        {
            var userNumber = UserContactDetailsList._userContactDetails.FirstOrDefault(s => s.UserId == userId);
            if (userNumber == null)
            {
                UserContactDetailsList._userContactDetails.Add(new UserContactDetails
                {
                    Id = new Random().Next(10000),
                    UserId = userId,
                    MobileNumber = model.MobileNumber
                });
            }
            else
            {
                userNumber.MobileNumber = model.MobileNumber;
            }
            return true;
        }
    }
}
