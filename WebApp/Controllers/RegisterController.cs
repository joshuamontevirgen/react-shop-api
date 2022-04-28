using Core.Domain.Users;
using Core.Services.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Models.UserModels;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        IUserService _userService;
        public RegisterController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public ActionResult<ReturnValue> Post([FromBody] RegisterUserModel model)
        {
            var exist = _userService.GetByEmail(model.Email);
            if (exist != null)
            {
                return new ReturnValue
                {
                    Success = false,
                    Message = "Email is already taken"
                };
            }
            var user = _userService.Add(new User
            {
                Email = model.Email,
                Password = model.Password,
            });
            return new ReturnValue
            {
                Success = true,
                Message = "Registration success"
            };
        }

    }
}
