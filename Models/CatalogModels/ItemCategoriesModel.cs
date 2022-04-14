using System.Collections.Generic;
using WebApplication3.tempDB;
using System.Linq;

namespace WebApplication3.Models.CatalogModels
{
    public class ItemCategoriesModel
    {
        public string Value { get; set; }
        public string Label { get; set; }
        public IEnumerable<ItemCategoriesModel> Children { get; set; }

        public string Parent { get; set; }

        public static List<ItemCategoriesModel> ToModel(IEnumerable<ItemCategory> cats)
        {
            return cats.Where(c => c.Parent == null).Select(c => new ItemCategoriesModel
            {
                Value = c.Value,
                Label = c.Label,
                Parent = null,
                Children = cats.Where(c2 => c2.Parent == c.Value).Select(c3 => new ItemCategoriesModel
                {
                    Label = c3.Label,
                    Value = c3.Value,
                    Parent = c.Value
                })
            }).ToList();

        }
    }
}
