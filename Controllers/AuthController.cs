using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RolePlayingGameAPI.Data;
using RolePlayingGameAPI.Dtos.User;
using RolePlayingGameAPI.Models;

namespace RolePlayingGameAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRep;
        public AuthController(IAuthRepository authRep)
        {
            _authRep = authRep;

        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterDto request)
        {
            ServiceResponse<int> response = await _authRep.Register(
                new User { Username = request.Username }, request.Password
            );
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDto request)
        {
            ServiceResponse<string> response = await _authRep.Login(
                request.Username, request.Password
            );
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}