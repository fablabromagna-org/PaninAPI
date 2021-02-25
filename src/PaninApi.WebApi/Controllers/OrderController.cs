using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaninApi.Abstractions.Dtos;
using PaninApi.Abstractions.Exceptions;
using PaninApi.Abstractions.Models;
using PaninApi.Abstractions.Services;
using PaninApi.WebApi.Chains;

namespace PaninApi.WebApi.Controllers
{
    public class OrderController : BaseAuthApiController
    {
        private readonly IUserChain _userChain;

        private readonly IItemService _itemService;

        private readonly IOrderService _orderService;

        private readonly IMapper _mapper;

        public OrderController(IUserChain userChain, IItemService itemService, IOrderService orderService,
            IMapper mapper)
        {
            _userChain = userChain;
            _itemService = itemService;
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("/v1/[controller]")]
        public async Task<IActionResult> CreateOrder(OrderDto orderDto)
        {
            var userTask = _userChain.HandleAsync(HttpContext.User);

            var item = await _itemService.FindAsync(orderDto.ItemId);

            if (!await _itemService.IsAvailableAsync(item, orderDto.Quantity))
            {
                throw new ItemNotAvailableException(item, orderDto.Quantity);
            }

            if (!(await userTask is Student user))
            {
                return Forbid();
            }

            if (user.School.CoffeeShops.All(coffeeShop => coffeeShop != item.CoffeeShop))
            {
                throw new InvalidCoffeeShopForUserException(user, item.CoffeeShop);
            }

            var order = await _orderService.CreateNewOrderAsync(user, item);
            var dto = _mapper.Map<BasicOrderDto>(order);

            return Ok(dto);
        }

        [HttpPost]
        [Route("/v1/[controller]/complete")]
        public async Task<IActionResult> CreateOrder(CompleteOrderDto completeOrderDto)
        {
            
        }

        [HttpPut]
        [Route("/v1/[controller]/{orderId:guid}")]
        public async Task<IActionResult> UpdateOrder([FromBody] OrderDto newItem, Guid orderId)
        {
            var order = await _orderService.FindByIdAsync(orderId);
            var item = await _itemService.FindAsync(newItem.ItemId);
            var userTask = _userChain.HandleAsync(HttpContext.User);

            if (order.Items.First().Item.CoffeeShop == item.CoffeeShop)
            {
                throw new CoffeeShopConflictException(order.CoffeeShop, item);
            }

            if (!(await userTask is Student user))
            {
                return Forbid();
            }

            if (user.School.CoffeeShops.All(coffeeShop => coffeeShop != item.CoffeeShop))
            {
                throw new InvalidCoffeeShopForUserException(user, item.CoffeeShop);
            }
            
            _orderService.
        }

        [HttpDelete]
        [Route("/v1/[controller]/{orderId:guid}/{itemId:guid}")]
        public Task<IActionResult> DeleteItemFromOrder(Guid orderId, Guid itemId)
        {
        }

        [HttpDelete]
        [Route("/v1/[controller]/{orderId:guid}")]
        public Task<IActionResult> DeleteOrder(Guid orderId)
        {
        }

        [HttpGet]
        public Task<IActionResult> Orders()
        {
            
        }
    }
}