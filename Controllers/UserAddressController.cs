using Core.Domain.Users;
using Core.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication3.Models.UserModels;
using System.Linq;

namespace WebApplication3.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/user/address")]
    public class UserAddressController : BaseApiController
    {
        IUserAddressService _userAddressService;
        public UserAddressController(IUserAddressService userAddressService)
        {
            _userAddressService = userAddressService;
        }

        [HttpGet]
        public ActionResult<List<UserAddress>> Get()
        {
            return _userAddressService.GetUserAddresses(GetUserId()).ToList();
        }

        [HttpPost]
        public ActionResult<bool> Post([FromBody] UserAddress model)
        {
            model.UserId = GetUserId();
            return _userAddressService.Add(model) != null;
        }
    }
}
