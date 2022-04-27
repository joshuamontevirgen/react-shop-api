using Core.Domain.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Items
{
    public interface IItemCategoryService 
    {
        ItemCategory GetById(int id);
        List<ItemCategory> GetChildCategories(int parentId);
        ItemCategory Add(ItemCategory model);
        IEnumerable<ItemCategory> GetAll();
    }
}
