using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EinsamerWanderer.API.Controllers
{
    [ApiController]
    public class CharacterController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }
    }
}