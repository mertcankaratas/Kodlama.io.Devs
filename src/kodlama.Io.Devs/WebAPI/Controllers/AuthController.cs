using Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.Users.Commands.Login;
using Application.Features.Users.Commands.Register;
using Application.Features.Users.Dtos;
using Core.Security.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand registerUserCommand)
        {
            var result = await Mediator.Send(registerUserCommand);
            return Created("", result);
        }



        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand loginUserCommand)
        {
            var result = await Mediator.Send(loginUserCommand);
            return Created("", result);
        }
    }
}
