using System.Threading.Tasks;
using EinsamerWanderer.Auth.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace EinsamerWanderer.Auth.Controllers
{
    [ApiController]
    [Route("/login")]
    public class LoginController : Controller
    {
        private UserManager<EWUser> _userManager;
        private SignInManager<EWUser> _signInManager;
        private IJwtTokenHandler _jwtTokenHandler;
        public LoginController(UserManager<EWUser> userManager, SignInManager<EWUser> signInManager, IJwtTokenHandler jwtTokenHandler)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtTokenHandler = jwtTokenHandler;
        }

        [HttpPost]
        public async Task RegisterAsync(string username, string email, string password)
        {
            await _userManager.CreateAsync(new EWUser { UserName = username, Email = email }, password);
        }

        [HttpGet]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            if(user is null)
            {
                return BadRequest();
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (result.Succeeded)
            {
                return Ok(new UserResponse
                {
                    UserId = user.Id,
                    Username = user.UserName,
                    JwtToken = _jwtTokenHandler.GenerateToken(user.Id)
                });
            }
            return BadRequest("Wrong Password");
        }
    }
}
