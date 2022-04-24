using Core.DB;
using Core.Domain.Items;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Items
{
    public class ItemCategoryService
    {
        IRepository<ItemCategory> _itemCategoryRepository;
        public ItemCategoryService(IRepository<ItemCategory> itemCategoryRepository)
        {
            //_itemCategoryRepository = _itemCategoryRepository;

            DbContextOptions<ShopContext> options = new Microsoft.EntityFrameworkCore.DbContextOptionsBuilder<ShopContext>()
            .UseInMemoryDatabase(databaseName: "Test")
            .Options;

            _itemCategoryRepository = new Repository<ItemCategory>(new ShopContext(options));
        }


        public ItemCategory GetById(int id)
        {
            return _itemCategoryRepository.GetByID(id);
        }
        public List<ItemCategory> GetChildCategories(int parentId)
        {
            return _itemCategoryRepository.Get(filter: s => s.ParentId == parentId).ToList();
        }


        public void Add(ItemCategory model)
        {
            _itemCategoryRepository.Insert(model);
            _itemCategoryRepository.Save();
        }
        public IEnumerable<ItemCategory> GetAll()
        {
           return _itemCategoryRepository.GetAll();
        }
    }
}
