using AutoMapper;
using Core.Domain.Users;
using Core.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models.UserModels;

namespace WebApplication3.Controllers
{
    [Route("api/user/[controller]")]
    [ApiController]
    [Authorize]
    public class ProfileController : BaseApiController
    {

        IUserService _userService;
        IMapper mapper;
        public ProfileController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            this.mapper = mapper;
        }

        // GET api/<ValuesController>/5
        [Authorize]
        [HttpGet]
        public ActionResult<UserModel> Get()
        {
            var id = GetUserId();
            return mapper.Map<UserModel>(_userService.GetById(id));
        }

        // PUT api/<ValuesController>/5
        [HttpPut]
        public void Put([FromBody] UserModel model)
        {
            model.Id = GetUserId();
            _userService.Update(mapper.Map<User>(model));
        }

    }
}
