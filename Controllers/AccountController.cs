using Blog.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly TokenService _tokenService;
        public AccountController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

       // [AllowAnonymous] //Apesar do Authorize do Controller, ele vai liberar o metódo login, sem estar logado
        [HttpPost("v1/login")]
        public IActionResult Login()
        {

            var token = _tokenService.GenerateToken(null);
            return Ok(token);
        }

        [Authorize(Roles = "user")] //Pode ser usado no método ou no controller todo
        [HttpGet("v1/user")]
       public IActionResult GetUser() => Ok(User.Identity.Name);

        [Authorize(Roles = "author")]
        [HttpGet("v1/author")]
        public IActionResult GetAuthor() => Ok(User.Identity.Name);

        [Authorize(Roles = "admin")]
        [HttpGet("v1/admin")]
        public IActionResult GetAdmin() => Ok(User.Identity.Name);
    }
}
