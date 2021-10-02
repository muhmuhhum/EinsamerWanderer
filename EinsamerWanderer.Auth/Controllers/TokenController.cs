using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace EinsamerWanderer.Auth.Controllers
{
    [ApiController]
    [Route("/token")]
    public class TokenController : ControllerBase
    {
        private IJwtTokenHandler _jwtTokenHandler;
        private IConfiguration _configuration;

        public TokenController(IJwtTokenHandler jwtTokenHandler, IConfiguration configuration)
        {
            _jwtTokenHandler = jwtTokenHandler;
            _configuration = configuration;
        }
        
        [HttpGet]
        public IActionResult VerifyToken(string token)
        {
            if (_jwtTokenHandler.IsValidToken(token))
            {
                return NoContent();
            }
            return BadRequest();
        }
    }
}