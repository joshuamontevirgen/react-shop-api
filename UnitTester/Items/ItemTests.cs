using Core.Services.Items;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace UnitTester.Items
{
    public class ItemTests
    {
        IItemCategoryService _itemCategoryService;
        IItemService _itemService;
        [SetUp]
        public void Setup()
        {
            var provider = new SetupDI();
            _itemCategoryService = provider.GetService<IItemCategoryService>();
            _itemService = provider.GetService<IItemService>();
        }

        [Test]
        public void AddItem()
        {
            var category = new Core.Domain.Items.ItemCategory
            {
                Label = "zz",
                Value = "zz",
                ParentId = null,
            };
            _itemCategoryService.Add(category);

            var item = new Core.Domain.Items.Item
            {
                Desc = "desc",
                ImageUrl = "url",
                ItemCategoryId = category.Id,
                Name = "name",
                Price = 1M
            };
            _itemService.Add(item);

            var itemGet = _itemService.GetById(item.Id);
            itemGet.Should().BeEquivalentTo(item);
        }


        [Test]
        public void GetByCategory()
        {
            var category1 = new Core.Domain.Items.ItemCategory
            {
                Label = "zz",
                Value = "zz",
                ParentId = null,
            };
            _itemCategoryService.Add(category1);
            var category2 = new Core.Domain.Items.ItemCategory
            {
                Label = "zz",
                Value = "zz",
                ParentId = null,
            };
            _itemCategoryService.Add(category2);


            _itemService.Add(new Core.Domain.Items.Item
            {
                Desc = "desc",
                ImageUrl = "url",
                ItemCategoryId = category1.Id,
                Name = "name",
                Price = 1M
            });
            _itemService.Add(new Core.Domain.Items.Item
            {
                Desc = "desc",
                ImageUrl = "url",
                ItemCategoryId = category2.Id,
                Name = "name",
                Price = 1M
            });
            _itemService.Add(new Core.Domain.Items.Item
            {
                Desc = "desc",
                ImageUrl = "url",
                ItemCategoryId = category2.Id,
                Name = "name",
                Price = 1M
            });

            var items = _itemService.GetByCategoryId(category2.Id);
            Assert.IsTrue(items.Count() == 2);
        }
    }
}
