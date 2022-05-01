using Core.Domain.Orders;
using Core.Domain.Items;
using Core.Repositories;
using Core.Services.Orders.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.OrderItems
{
    public class OrderItemService : IOrderItemService
    {
        IRepository<OrderItem> _repository;
        IRepository<Item> _itemsRepository;
        public OrderItemService(IRepository<OrderItem> OrderItemRepository, IRepository<Item> itemsRepository)
        {
            _repository = OrderItemRepository;
            _itemsRepository = itemsRepository;
        }
        public OrderItem Add(Order order, OrderItem item)
        {
            item.OrderId = order.Id;
            item.Price = _itemsRepository.GetByID(item.ItemId).Price;
            return _repository.Insert(item);
        }

        public List<OrderItem> Add(Order order, List<OrderItem> items)
        {
            items.ForEach(item => 
            {
                item.OrderId = order.Id;
                item.Price = _itemsRepository.GetByID(item.ItemId).Price;
            });
            return _repository.Insert(items);
        }

        public IEnumerable<OrderItem> GetAll()
        {
            return _repository.GetAll();
        }

        public OrderItem GetById(int id)
        {
            return _repository.GetByID(id);
        }

        public IEnumerable<OrderItem> GetOrderItems(int orderId)
        {
            return _repository.Filter(filter: s => s.OrderId == orderId);
        }

        public OrderItem Update(OrderItem model)
        {
            return _repository.Update(model);
        }
    }
}
