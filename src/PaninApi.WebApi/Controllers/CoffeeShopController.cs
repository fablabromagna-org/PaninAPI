using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaninApi.Abstractions.Dtos;
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
        [Route("/v1/[controller]/{coffeeShopId:int}/[action]/{page:int?}")]
        public async Task<IActionResult> Items(int coffeeShopId, int page = 1)
        {
            if (coffeeShopId < 1)
            {
                return BadRequest(new ProblemDetails
                {
                    Title = "Invalid coffee shop id.",
                    Detail = $"Requested coffee shop with id #{coffeeShopId} but it is invalid."
                });
            }

            if (page < 1)
            {
                page = 1;
            }

            var coffeeShop = await _coffeeShopService.GetByIdAsync(coffeeShopId).ConfigureAwait(false);

            if (coffeeShop is null)
            {
                return NotFound(new ProblemDetails()
                {
                    Title = "Coffee shop not found.",
                    Detail = $"Requested coffee shop with id #{coffeeShopId} but it does not exists."
                });
            }

            var items = coffeeShop.Items.OrderBy(_ => _.Id).Skip((page - 1) * 10).Take(10);

            var dto = new PagingDto<ItemDto>
            {
                Total = coffeeShop.Items.Count(),
                Count = items.Count(),
                CurrentPage = page,
                Values = _mapper.Map<IEnumerable<ItemDto>>(items)
            };

            return Ok(dto);
        }
    }
}