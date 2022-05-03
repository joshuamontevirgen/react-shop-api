using Core.Domain.Orders;
using WebApplication3.Models.OrderModels;

namespace WebApplication3.Models.Factories
{
    public interface IOrderItemModelFactory
    {
        OrderItemModel ToModel(OrderItem item);
    }
}
