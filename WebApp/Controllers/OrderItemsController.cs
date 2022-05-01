using Core.Domain.Orders;
using Core.Services.Orders.Interfaces;
using Core.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication3.Models;
using System.Linq;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderItemsController : ControllerBase
    {
        IOrderItemService _orderItemService;
        public OrderItemsController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [HttpGet("{orderId}")]
        public ActionResult<List<OrderItem>> Get(int orderId)
        {
            return _orderItemService.GetOrderItems(orderId).ToList();
        } 
    }
}
