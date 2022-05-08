using Core.Domain.Orders;
using System.Collections.Generic;
using WebApplication3.Helpers;
using WebApplication3.Models.OrderModels;
using System.Linq;
using Core.Services.Users;
using Core.Payments;
using Core.Services.Orders;

namespace WebApplication3.Models.Factories
{
    public class OrderModelFactory : IOrderModelFactory
    {
        IUserAddressService _userAddressService;
        public OrderModelFactory(IUserAddressService userAddressService)
        {
            _userAddressService = userAddressService;
        }
        public List<OrderModel> ToModel(List<Order> orders)
        {            
            return orders.Select(s => ToModel(s)).ToList();
        }
        public OrderModel ToModel(Order order)
        {
            var model = new OrderModel();
            order.ShallowConvert(model);
            model.Address = _userAddressService.GetById(order.UserAddressId);
            return model;
        }
        public PlacedOrderModel ToModel(PlaceOrderResult orderResult)
        {
            var model = new PlacedOrderModel();
            var order = orderResult.Order;
            order.ShallowConvert(model);
            model.Address = _userAddressService.GetById(order.UserAddressId);
            model.PaymentProcess = orderResult.PaymentProcess;
            return model;
        }
    }
}
