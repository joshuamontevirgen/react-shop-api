using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication3.tempDB
{
    public class Items
    {
        public static List<Item> _items = new List<Item> ();
        static Items()
        {
            _items = GenerateItems();
        }
        private static List<Item> GenerateItems()
        {
            var random = new Random();

            var categories = ItemCategories._categories;//.Where(s => s.Parent != null).ToList();

            var parentCategories = categories.Where(s => s.Parent != null).ToList();
            var parentCategoriesNoChildren = categories.Where(s => s.Parent == null && !categories.Where(q => q.Parent != null).Select(q => q.Parent).Contains(s.Parent)).ToList();
            parentCategories = parentCategories.Concat(parentCategoriesNoChildren).ToList();

            var list = new List<Item>();
            for (int i = 0; i < 200; i++)
            {
                var category = parentCategories[random.Next(parentCategories.Count())];
                list.Add(new Item
                {
                    Id = i,
                    Category = category.Value,
                    Desc = $"desc-{i}",
                    ImageUrl = "https://localhost:44329/img/itm.jpg",
                    Price = Convert.ToDecimal(random.NextDouble() * random.NextInt64(1000)),
                    Name = $"{category.Value }-{i}"

                });
            }
            return list;
            //return Items._items.Select(s => _mapper.Map<ItemModel>(s));
        }

     
    }
}
