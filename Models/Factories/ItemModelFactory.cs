using Core.Domain.Items;
using Core.Services.Items;
using System.Collections.Generic;
using WebApplication3.Helpers;
using WebApplication3.Models.CatalogModels;
using System.Linq;

namespace WebApplication3.Models.Factories
{
    public class ItemModelFactory : IItemModelFactory
    {
        IItemCategoryService _itemCategoryService;
        public ItemModelFactory(IItemCategoryService itemCategoryService)
        {
            _itemCategoryService = itemCategoryService;
        }

        public List<ItemModel> GetListModel(IEnumerable<Item>items)
        {
            var cats = _itemCategoryService.GetAll();
            var list = new List<ItemModel>();

            foreach (var item in items)
            {
                var model = new ItemModel();
                item.ShallowConvert(model);
                model.Category = cats.FirstOrDefault(s => s.Id == item.ItemCategoryId).Value;
                list.Add(model);
            }
            return list;
        }
    }
}
