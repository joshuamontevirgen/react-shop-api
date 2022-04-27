using Core.Domain.Items;
using Core.Services.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTester.DataGenerators.Interfaces;

namespace UnitTester.DataGenerators
{
    public class ItemDataGenerator : IItemDataGenerator
    {
        IItemService _itemService;
        IItemCategoryService _categoryService;
        public ItemDataGenerator(IItemService itemService, IItemCategoryService categoryService)
        {
            _itemService = itemService;
            _categoryService = categoryService;
        }
        public ItemCategory AddCategory(int? parentId = null)
        {
            var category1 = new ItemCategory
            {
                Label = $"{Guid.NewGuid()}",
                Value = $"{Guid.NewGuid()}",
                ParentId = parentId,
            };
            return _categoryService.Add(category1);
        }

        public Item AddItem(int? categoryId = null)
        {
            var item = new Item
            {
                Desc = $"{Guid.NewGuid()}",
                ImageUrl = $"{Guid.NewGuid()}",
                ItemCategoryId = categoryId ?? AddCategory().Id,
                Name = $"{Guid.NewGuid()}",
                Price = 1M
            };
            return _itemService.Add(item);
        }
    }
}
