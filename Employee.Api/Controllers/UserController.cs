using Employee.Domain.Dtos;
using Employee.Domain.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserDto registerDto)
        {
           var result = await _userService.Register(registerDto);
            return Ok(result);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Register(LoginDto loginDto)
        {
            var result = await _userService.Login(loginDto);
            return Ok(result);
        }
    }
}
