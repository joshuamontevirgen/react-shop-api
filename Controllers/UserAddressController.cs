using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication3.Models.UserModels;
using WebApplication3.Services;

namespace WebApplication3.Controllers
{
    [ApiController]
    [EnableCors]
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
        public ActionResult<List<UserAddressModel>> Get()
        {
            return _userAddressService.GetByUserId(GetUserId());
        }

        [HttpPost]
        public ActionResult<bool> Post([FromBody]UserAddressModel model)
        {
            return _userAddressService.Add(GetUserId(), model);
        }
    }
}
