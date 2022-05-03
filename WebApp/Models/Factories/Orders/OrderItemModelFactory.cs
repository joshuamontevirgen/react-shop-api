using Core.Domain.Orders;
using Core.Services.Items;
using WebApplication3.Helpers;
using WebApplication3.Models.OrderModels;

namespace WebApplication3.Models.Factories
{
    public class OrderItemModelFactory : IOrderItemModelFactory
    {
        IItemService _itemService;
        public OrderItemModelFactory(IItemService itemService)
        {
            _itemService = itemService;
        }
        public OrderItemModel ToModel(OrderItem item)
        {
            var model = new OrderItemModel();
            item.ShallowConvert(model);
            model.Item = _itemService.GetById(item.ItemId);
            return model;
        }
    }
}
