using Core.Domain.Orders;
using System.Collections.Generic;
using WebApplication3.Helpers;
using WebApplication3.Models.OrderModels;
using System.Linq;
using Core.Services.Users;
using Core.Payments;
using Core.Services.Orders;
using Core.Services.Orders.Interfaces;

namespace WebApplication3.Models.Factories
{
    public class OrderModelFactory : IOrderModelFactory
    {
        IUserAddressService _userAddressService;
        IOrderItemService _orderItemService;
        IOrderItemModelFactory _orderItemModelFactory;
        public OrderModelFactory(IUserAddressService userAddressService, IOrderItemService orderItemService, IOrderItemModelFactory orderItemModelFactory)
        {
            _userAddressService = userAddressService;
            _orderItemService = orderItemService;
            _orderItemModelFactory = orderItemModelFactory;
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
            model.Items = _orderItemService.GetOrderItems(order.Id).Select(s => _orderItemModelFactory.ToModel(s)).ToList();

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
