using Core.Domain.Orders;
using Core.Repositories;
using Core.Services.Orders.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Orders
{
    public class OrderService : IOrderService
    {
        IRepository<Order> _repository;
        public OrderService(IRepository<Order> orderRepository)
        {
            _repository = orderRepository;
        }
        public Order Add(Order model)
        {
            return _repository.Insert(model);
        }

        public IEnumerable<Order> GetAll()
        {
            return _repository.GetAll();
        }

        public Order GetById(int id)
        {
            return _repository.GetByID(id);
        }

        public IEnumerable<Order> GetUserOrders(int userId)
        {
            return _repository.Filter(filter: s => s.UserId == userId);
        }

        public Order Update(Order model)
        {
            return _repository.Update(model);
        }
    }
}
