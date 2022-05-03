using Core.Domain.Orders;
using Core.Services.Orders.Interfaces;
using Core.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication3.Models;
using System.Linq;
using WebApplication3.Models.Factories;
using WebApplication3.Models.OrderModels;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderItemsController : ControllerBase
    {
        IOrderItemService _orderItemService;
        IOrderItemModelFactory _orderItemModelFactory;
        public OrderItemsController(IOrderItemService orderItemService, IOrderItemModelFactory orderItemModelFactory)
        {
            _orderItemService = orderItemService;
            _orderItemModelFactory = orderItemModelFactory;
        }

        [HttpGet("{orderId}")]
        public ActionResult<List<OrderItemModel>> Get(int orderId)
        {
            return _orderItemService.GetOrderItems(orderId).Select(s => _orderItemModelFactory.ToModel(s)).ToList();
        } 
    }
}
