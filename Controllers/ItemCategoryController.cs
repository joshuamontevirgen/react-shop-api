using Core.Domain.Items;
using Core.Services.Items;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication3.Models;
using WebApplication3.Models.CatalogModels;
using WebApplication3.Models.Factories;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemCategoryController : ControllerBase
    {
        private readonly IItemCategoryService _itemCategoryService;
        private readonly IItemCategoriesModelFactory _factory;
        public ItemCategoryController(IItemCategoryService itemCategory, IItemCategoriesModelFactory factory)
        {
            _itemCategoryService = itemCategory; 
            _factory = factory;
        }
        [HttpGet]
        public ActionResult<List<ItemCategoriesModel>> Get()
        {
            return _factory.GetItemCategories();
        }

    }
}
