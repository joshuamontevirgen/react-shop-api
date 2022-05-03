using Core.Domain.Items;
using Core.Domain.Orders;

namespace WebApplication3.Models.OrderModels
{
    public class OrderItemModel : OrderItem
    {
        public Item Item { get; set; }
    }
}
