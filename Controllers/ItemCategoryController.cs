using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication3.Models.CatalogModels;
using WebApplication3.Services;
using WebApplication3.tempDB;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class ItemCategoryController : ControllerBase
    {
        private readonly IItemCategoryService _itemCategoryService;
        public ItemCategoryController(IItemCategoryService itemCategory)
        {
            _itemCategoryService = itemCategory; 
        }
        [HttpGet]
        public ActionResult<List<ItemCategoriesModel>> Get()
        {
            return ItemCategoriesModel.ToModel( _itemCategoryService.GetList());
        }

    }
}
