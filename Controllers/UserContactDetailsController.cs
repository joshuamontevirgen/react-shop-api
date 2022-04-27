using Core.Domain.Users;
using Core.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models.UserModels;

namespace WebApplication3.Controllers
{
    [ApiController]
    [EnableCors]
    [Authorize]
    [Route("api/user/contactdetails")]
    public class UserContactDetailsController : BaseApiController
    {
        IUserContactDetailsService _contactDetailsService;
        public UserContactDetailsController(IUserContactDetailsService contactDetailsService)
        {
            _contactDetailsService = contactDetailsService;
        }

        [HttpGet]
        public ActionResult<UserContactDetails> Get()
        {
            return _contactDetailsService.GetByUserId(GetUserId());
        }

        [HttpPost]
        public ActionResult<bool> Post([FromBody] UserContactDetails model)
        {
            model.UserId = GetUserId(); 
            return _contactDetailsService.Save(model) != null;
        }
    }
}
