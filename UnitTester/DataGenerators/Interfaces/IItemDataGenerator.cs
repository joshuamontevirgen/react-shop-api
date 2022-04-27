using Core.Domain.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTester.DataGenerators.Interfaces
{
    public interface IItemDataGenerator
    {
        ItemCategory AddCategory(int? parentId = null);
        Item AddItem(int? categoryId = null);
    }
}
