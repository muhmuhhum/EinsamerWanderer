using EinsamerWanderer.API.Model;
using EinsamerWanderer.API.Queries;
using EinsamerWanderer.API.RestContract.V1;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EinsamerWanderer.API.Commands;
using EinsamerWanderer.API.Request;
using EinsamerWanderer.API.Response;

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

        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ItemResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost(Routes.Item.Create)]
        public async Task<IActionResult> Create([FromBody] CreateItemRequest createItemRequest)
        {
            try
            {
                var result = await _mediator.Send(new CreateItemCommand(createItemRequest));
                if (result.Successfull)
                {
                    return CreatedAtAction(nameof(Get), new { itemId = result.Payload.Id}, result);
                }

                return BadRequest(result);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Unhandled exception in ItemController GetAll");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Item>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet(Routes.Item.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _mediator.Send(new GetAllItemsQuery());
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Unhandled exception in ItemController GetAll");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Item))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet(Routes.Item.Get)]
        public async Task<IActionResult> Get(Guid itemId)
        {
            try
            {
                var result = await _mediator.Send(new GetItemByIdQuery(itemId));
                if (result is null)
                {
                    return NotFound(itemId);
                }
                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Unhandled exception in ItemController Get");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Item))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut(Routes.Item.Update)]
        public async Task<IActionResult> Update(Guid itemId, [FromBody] UpdateItemRequest updateItemRequest)
        {
            try
            {
                var result = await _mediator.Send(new UpdateItemCommand(itemId, updateItemRequest));
                if (result.Successfull)
                {
                    return Ok(result);
                }

                return BadRequest(result);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Unhandled exception in ItemController Update");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Item))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete(Routes.Item.Delete)]
        public async Task<IActionResult> Delete(Guid itemId)
        {
            try
            {
                var result = await _mediator.Send(new DeleteItemCommand(itemId));
                if (result.Successfull)
                {
                    return Ok(result);
                }

                return BadRequest(result);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Unhandled exception in ItemController Update");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
