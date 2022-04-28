using Core.Domain.Items;
using Core.Domain.Users;
using Core.Services.Items;
using Core.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication3.Models.CatalogModels;

namespace WebApplication3.DataGenerator
{
    public class TestDataGenerator : ITestDataGenerator
    {
        IItemService _itemService;
        IItemCategoryService _categoryService;
        IUserService _userService;
        public TestDataGenerator(IItemService itemService, IItemCategoryService categoryService, IUserService userService)
        {
            _itemService = itemService;
            _categoryService = categoryService;
            _userService = userService;
        }

        public void GenerateCategories()
        {
            var parent1 = _categoryService.Add(new ItemCategory { Value = "Frozen", Label = "Frozen" });
            _categoryService.Add(new ItemCategory { Value = "Meat", Label = "Meat", ParentId = parent1.Id });
            _categoryService.Add(new ItemCategory { Value = "Seafood", Label = "Seafood", ParentId = parent1.Id });
            _categoryService.Add(new ItemCategory { Value = "IceCream", Label = "Ice Cream", ParentId = parent1.Id });


            var parent2 = _categoryService.Add(new ItemCategory { Value = "Beverage", Label = "Beverage" });
            _categoryService.Add(new ItemCategory { Value = "Water", Label = "Water", ParentId = parent2.Id });
            _categoryService.Add(new ItemCategory { Value = "Juice", Label = "Juice", ParentId = parent2.Id });


            var parent3 = _categoryService.Add(new ItemCategory { Value = "Snacks", Label = "Snacks" });
            _categoryService.Add(new ItemCategory { Value = "Cookies", Label = "Cookies", ParentId = parent3.Id });
            _categoryService.Add(new ItemCategory { Value = "Candy", Label = "Candy", ParentId = parent3.Id });


            var parent4 = _categoryService.Add(new ItemCategory { Value = "Other", Label = "Other" });
        }

        public void GenerateItems()
        {
            var random = new Random();

            var categories = new List<ItemCategory>();
            var parentCategories = _categoryService.GetParentCategories();

            var parents = _categoryService.GetParentCategories();
            foreach (var parent in parents)
            {
                var children = _categoryService.GetChildCategories(parent.Id);
                foreach (var child in children)
                {
                    categories.Add(child);
                }
                if(children.Count == 0)
                {
                    categories.Add(parent);
                }
                
            }

            var list = new List<Item>();
            for (int i = 0; i < 500; i++)
            {
                var category = categories[random.Next(categories.Count())];
                _itemService.Add(new Item
                {
                    ItemCategoryId = category.Id,
                    Desc = $"desc-{i}",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRl4DVWvAO7RQ2wDrUrmviP4Kt3eTEAppgUTNQUnFLkytu2r6RPy_7BCjoWokhI3uf8e4Y&usqp=CAU",
                    Price = Convert.ToDecimal(random.NextDouble() * random.NextInt64(1000)),
                    Name = $"{category.Value }-{i}"

                });
            }      
        }

        public void GenerateUsers()
        {
            _userService.Add(new User { Email = "qwe@qwe.com", Id = 1, Password = "qwe" });
        }
    }
}
