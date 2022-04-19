using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models.UserModels;
using WebApplication3.Services;

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
        public ActionResult<ContactDetailsModel> Get()
        {
            return _contactDetailsService.Get(GetUserId());
        }

        [HttpPost]
        public ActionResult<bool> Post([FromBody] ContactDetailsModel model)
        {
            return _contactDetailsService.Save(GetUserId(), model);
        }
    }
}
