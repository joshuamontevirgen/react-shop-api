using Core.Domain.Items;
using Core.Services.Items;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplication3.Models.CatalogModels;
using WebApplication3.Models.Factories;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : BaseApiController
    {
        private readonly IItemService _itemService;
        private readonly IItemModelFactory _factory;
        public CatalogController(IItemService itemService, IItemModelFactory factory)
        {
            _itemService = itemService;
            _factory = factory;
        }
        [HttpGet]
        public ActionResult<List<ItemModel>> Get() 
        {
            return _factory.GetListModel(_itemService.GetAll());
        }
    }
}
