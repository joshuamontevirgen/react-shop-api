using Core.Services.Items;
using NUnit.Framework;
using FluentAssertions;

namespace UnitTester
{
    public class ItemCategoryTests 
    {
        IItemCategoryService _itemCategoryService;
        [SetUp]
        public void Setup()
        {
            var provider = new SetupDI();          
            _itemCategoryService = provider.GetService<IItemCategoryService>();
        }

        [Test]
        public void AddItemCategory()
        {
            var category = new Core.Domain.Items.ItemCategory
            {
                Label = "zz",
                Value = "zz",
                ParentId = null,
            };
            _itemCategoryService.Add(category);

            var categoryGet = _itemCategoryService.GetById(category.Id);
            categoryGet.Should().BeEquivalentTo(category);
        }

        [Test]
        public void GetChildCategories()
        {
            var parent = _itemCategoryService.Add(new Core.Domain.Items.ItemCategory
            {
                Label="one",
                Value="one",
                ParentId=null,
            });
           
            _itemCategoryService.Add(new Core.Domain.Items.ItemCategory
            {
                Label = "child-one1",
                Value = "child-one1",
                ParentId = parent.Id,
            });
            _itemCategoryService.Add(new Core.Domain.Items.ItemCategory
            {
                Label = "child-one2",
                Value = "child-one2",
                ParentId = parent.Id,
            });

            _itemCategoryService.Add(new Core.Domain.Items.ItemCategory
            {
                Id = 3232323,
                Label = "child-one1",
                Value = "child-one1",
                ParentId = null,
            });
            _itemCategoryService.Add(new Core.Domain.Items.ItemCategory
            {
                Label = "child-one2",
                Value = "child-one2",
                ParentId = 3232323,
            });
    
            var childCategories = _itemCategoryService.GetChildCategories(parent.Id);
            Assert.IsTrue(childCategories.Count == 2);
        }
    }
}