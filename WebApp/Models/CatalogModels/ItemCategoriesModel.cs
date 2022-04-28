using Core.Domain.Items;
using Core.Services.Items;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication3.Models.CatalogModels
{
    public class ItemCategoriesModel : ItemCategory
    {
        public ItemCategoriesModel()
        {
            Children = new List<ItemCategoriesModel>();
        }
        public List<ItemCategoriesModel> Children { get; set; }
        public ItemCategory Parent { get; set; }


  
    }
}
