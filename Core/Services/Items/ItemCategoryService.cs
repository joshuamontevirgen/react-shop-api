using Core.DB;
using Core.Domain.Items;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Items
{
    public class ItemCategoryService : IItemCategoryService
    {
        IRepository<ItemCategory> _itemCategoryRepository;
        public ItemCategoryService(IRepository<ItemCategory> itemCategoryRepository)
        {
            _itemCategoryRepository = itemCategoryRepository;
        }

        public ItemCategory GetById(int id)
        {
            return _itemCategoryRepository.GetByID(id);
        }
        public List<ItemCategory> GetChildCategories(int parentId)
        {
            return _itemCategoryRepository.Filter(filter: s => s.ParentId == parentId).ToList();
        }

        public ItemCategory Add(ItemCategory model)
        {
            return _itemCategoryRepository.Insert(model);
        }
        public IEnumerable<ItemCategory> GetAll()
        {
           return _itemCategoryRepository.GetAll();
        }
    }
}
