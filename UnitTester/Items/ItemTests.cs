using Core.Services.Items;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using UnitTester.DataGenerators.Interfaces;

namespace UnitTester.Items
{
    public class ItemTests
    {
        IItemCategoryService _itemCategoryService;
        IItemService _itemService;
        IItemDataGenerator _generator;
        [SetUp]
        public void Setup()
        {
            var provider = new SetupDI();
            _itemCategoryService = provider.GetService<IItemCategoryService>();
            _itemService = provider.GetService<IItemService>();
            _generator = provider.GetService<IItemDataGenerator>();
        }

        [Test]
        public void AddItem()
        {
            var category = _generator.AddCategory();

            var item = _generator.AddItem(category.Id);

            var itemGet = _itemService.GetById(item.Id);
            itemGet.Should().BeEquivalentTo(item);
        }


        [Test]
        public void GetByCategory()
        {
            var category1 = _generator.AddCategory();
            var category2 = _generator.AddCategory();

            _generator.AddItem(category1.Id);
            _generator.AddItem(category2.Id);
            _generator.AddItem(category2.Id);

            var items = _itemService.GetByCategoryId(category2.Id);
            Assert.IsTrue(items.Count() == 2);
        }
    }
}
