using EKart.Application.Commands.UserCommands;
using EKart.Core.DTOs;
using EKart.Core.Generics;
using EKart.Core.IRepositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Kart_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IMediator mediator) : ControllerBase
    {
        [HttpPost("register-user")]
        public async Task<IActionResult> RegisterUser([FromBody] LoginDto dto)
        {
            var result = await mediator.Send(new UserRegistrationCommand(dto));
            if (result == "Email and password cannot be empty." || result == "Email is already registered.")
            {
                return BadRequest(result);
            }
            return Ok(ApiResponse.Success(result, "User Created Successfully"));
        }
    }
}
