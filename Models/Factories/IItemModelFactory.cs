using Core.Domain.Items;
using System.Collections.Generic;
using WebApplication3.Models.CatalogModels;

namespace WebApplication3.Models.Factories
{
    public interface IItemModelFactory
    {

        List<ItemModel> GetListModel(IEnumerable<Item> items);
    }
}
