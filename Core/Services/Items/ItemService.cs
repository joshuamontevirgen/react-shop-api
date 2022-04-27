using Core.Domain.Items;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Items
{
    public class ItemService : IItemService
    {
        IRepository<Item> _itemRepository;
        public ItemService(IRepository<Item> itemRepository)
        {
            _itemRepository = itemRepository;
        }
        public Item Add(Item model)
        {
            return _itemRepository.Insert(model);
        }

        public IEnumerable<Item> GetAll()
        {
            return _itemRepository.GetAll();
        }

        public IEnumerable<Item> GetByCategoryId(int id)
        {
            return _itemRepository.Filter(filter: s => s.ItemCategoryId == id);
        }


        public Item GetById(int id)
        {
            return _itemRepository.GetByID(id);
        }

        public Item Update(Item model)
        {
            return _itemRepository.Update(model);
        }
    }
}
