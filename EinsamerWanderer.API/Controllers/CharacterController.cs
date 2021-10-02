using System;
using System.Threading.Tasks;
using EinsamerWanderer.API.Request;
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

        [HttpPost]
        public async Task<IActionResult> Create(CreateCharacterRequest request)
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid characterId)
        {
            return Ok();
        }
    }
}