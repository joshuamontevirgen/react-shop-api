using Core.Domain.Orders;
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
        public OrderItemService(IRepository<OrderItem> OrderItemRepository)
        {
            _repository = OrderItemRepository;
        }
        public OrderItem Add(OrderItem model)
        {
            return _repository.Insert(model);
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
