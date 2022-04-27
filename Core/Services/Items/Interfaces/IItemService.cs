using Core.Domain.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Items
{
    public interface IItemService
    {
        Item GetById(int id);
        Item Add(Item model);
        Item Update(Item model);
        IEnumerable<Item> GetAll();
        IEnumerable<Item> GetByCategoryId(int id);
    }
}
