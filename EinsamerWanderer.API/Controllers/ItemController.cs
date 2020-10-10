using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EinsamerWanderer.API.Queries;
using EinsamerWanderer.API.RestContract.V1;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EinsamerWanderer.API.Controllers
{
    public class ItemController : Controller
    {
        private ILogger<ItemController> _logger;
        private IMediator _mediator;

        public ItemController(ILogger<ItemController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet(Routes.Item.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllItemsQuery());
            return Ok(result);
        }
    }
}
