using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaninApi.Abstractions.Dtos;
using PaninApi.Abstractions.Exceptions;
using PaninApi.Abstractions.Services;

namespace PaninApi.WebApi.Controllers
{
    public class CoffeeShopController : BaseAuthApiController
    {
        private readonly ICoffeeShopService _coffeeShopService;

        private readonly IMapper _mapper;

        public CoffeeShopController(ICoffeeShopService coffeeShopService, IMapper mapper)
        {
            _coffeeShopService = coffeeShopService;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("/v1/[controller]/{coffeeShopId:int}/[action]")]
        public async Task<IActionResult> Items(int coffeeShopId)
        {
            if (coffeeShopId < 1)
            {
                throw new InvalidCoffeeShopIdException(coffeeShopId);
            }

            var coffeeShop = await _coffeeShopService.GetByIdAsync(coffeeShopId).ConfigureAwait(false);

            if (coffeeShop is null)
            {
                throw new CoffeeShopNotFoundException(coffeeShopId);
            }

            var items = coffeeShop.Items.OrderBy(_ => _.Id);

            var dto = _mapper.Map<IEnumerable<ItemDto>>(items);

            return Ok(dto);
        }
    }
}