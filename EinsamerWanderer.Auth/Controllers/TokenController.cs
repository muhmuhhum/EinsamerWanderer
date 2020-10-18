using Microsoft.AspNetCore.Mvc;

namespace EinsamerWanderer.Auth.Controllers
{
    [ApiController]
    [Route("/token")]
    public class TokenController
    {
        private IJwtTokenHandler _jwtTokenHandler;

        public TokenController(IJwtTokenHandler jwtTokenHandler)
        {
            _jwtTokenHandler = jwtTokenHandler;
        }
        
        [HttpGet]
        public IActionResult VerifyToken(string token)
        {
            if (_jwtTokenHandler.IsValidToken(token))
            {
                return new NoContentResult();
            }
            return new BadRequestResult();
        }
    }
}