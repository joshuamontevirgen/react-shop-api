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
using System.Threading.Tasks;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : BaseApiController
    {
        IUserService _userService;
        IOrderProcessingService _orderProcessingService;
        IOrderService _orderService;
        IOrderModelFactory _orderModelFactory;
        public OrderController(IOrderProcessingService orderProcessingService, IOrderService orderService, IOrderModelFactory orderModelFactory)
        {
            _orderProcessingService = orderProcessingService;
            _orderService = orderService;
            _orderModelFactory = orderModelFactory;
        }

        [HttpGet]
        public ActionResult<List<OrderModel>> Get()
        {
            return _orderModelFactory.ToModel(_orderService.GetUserOrders(GetUserId()).ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<OrderModel> Get(int id)
        {
            return _orderModelFactory.ToModel(_orderService.GetById(id));
        }


        [HttpPost]
        public async Task<ActionResult<ReturnValue<PlacedOrderModel>>> Post([FromBody] CheckoutModel model)
        {
            model.Order.UserId = GetUserId();
            model.Order.Date = System.DateTime.Now;
            var placeOrderResult = await _orderProcessingService.PlaceOrderAsync(model.Order, model.OrderItems);
            return new ReturnValue<PlacedOrderModel>
            {
                Success = true,
                Message = "Order placed",
                Data = _orderModelFactory.ToModel(placeOrderResult)
            };
        }
    }
}
