using AutoMapper;
using Core.Domain.Items;
using Core.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models.CatalogModels;
using WebApplication3.Models.UserModels;

namespace WebApplication3.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>();
            CreateMap<Item, ItemModel>();
            CreateMap<ItemModel, Item>();
            CreateMap<AddressModel, UserAddress>();
            CreateMap<UserAddress, AddressModel>();
            CreateMap<ContactDetailsModel, UserContactDetails>();
            CreateMap<UserContactDetails, ContactDetailsModel>();
        }
    }
}
