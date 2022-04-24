using Core.Domain.Services.Users;
using Core.Services.Items;
using NUnit.Framework;

namespace UnitTester
{
    public class Tests
    {
        ItemCategoryService _itemCategoryService;
        [SetUp]
        public void Setup()
        {
            _itemCategoryService = new ItemCategoryService(null);
        }

        [Test]
        public void AddCategories()
        {
            _itemCategoryService.Add(new Core.Domain.Items.ItemCategory
            {
                Label="one",
                Value="one",
                ParentId=null,
            });
           
            _itemCategoryService.Add(new Core.Domain.Items.ItemCategory
            {
                Label = "child-one1",
                Value = "child-one1",
                ParentId = 1,
            });
            _itemCategoryService.Add(new Core.Domain.Items.ItemCategory
            {
                Label = "child-one2",
                Value = "child-one2",
                ParentId = 1,
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
    
            var childCategories = _itemCategoryService.GetChildCategories(1);

            Assert.IsTrue(childCategories.Count == 2);
        }
    }
}