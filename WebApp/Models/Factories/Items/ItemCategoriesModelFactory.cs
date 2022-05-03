using Core.Services.Items;
using System.Collections.Generic;
using WebApplication3.Helpers;
using WebApplication3.Models.CatalogModels;

namespace WebApplication3.Models.Factories
{
    public class ItemCategoriesModelFactory : IItemCategoriesModelFactory
    {
        IItemCategoryService _itemCategoryService;
        public ItemCategoriesModelFactory(IItemCategoryService itemCategoryService)
        {
            _itemCategoryService = itemCategoryService;
        }
      
        public List<ItemCategoriesModel> GetItemCategories()
        {
            var parents = _itemCategoryService.GetParentCategories();
            var cats = new List<ItemCategoriesModel>();
            foreach (var parent in parents)
            {
                var parentModel = new ItemCategoriesModel();
                parent.ShallowConvert(parentModel);
                cats.Add(parentModel);

                var children = _itemCategoryService.GetChildCategories(parent.Id);
                foreach(var child in children)
                {
                    var childModel = new ItemCategoriesModel();
                    child.ShallowConvert(childModel);

                    childModel.Parent = new ItemCategoriesModel();
                    parent.ShallowConvert(childModel.Parent);
                    parentModel.Children.Add(childModel);
                }
            }
            return cats;
        }


    }
}
