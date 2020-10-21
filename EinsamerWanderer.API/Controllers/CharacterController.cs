using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EinsamerWanderer.API.Controllers
{
    [ApiController]
    public class CharacterController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get(Guid characterId)
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok();
        }
    }
}