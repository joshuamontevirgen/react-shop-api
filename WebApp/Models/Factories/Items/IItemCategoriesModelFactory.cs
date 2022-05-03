using System.Collections.Generic;
using WebApplication3.Models.CatalogModels;

namespace WebApplication3.Models.Factories
{
    public interface IItemCategoriesModelFactory
    {
        List<ItemCategoriesModel> GetItemCategories();
    }
}
