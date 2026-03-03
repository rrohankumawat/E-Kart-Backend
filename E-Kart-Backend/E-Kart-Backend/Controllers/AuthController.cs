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
            try
            {
                if (result.Item1 == 1)
                {
                    return BadRequest(ApiResponse.Failure<string>(result.Item2));
                }
                else if (result.Item1 == 2 || result.Item1 == 0)
                {
                    return Ok(ApiResponse.Failure<string>(result.Item2));
                }
                return Ok(ApiResponse.Success(result, result.Item2));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse.Failure<string>(result.Item2));
            }
        }

        [HttpPost("login-user")]
        public async Task<IActionResult> LoginUser([FromBody] LoginDto dto)
        {
            var result = await mediator.Send(new UserLoginCommand(dto));
            try
            {
                if (result.Item1 == 1 || result.Item1 == 0)
                {
                    return Ok(ApiResponse.Failure<string>(result.Item2));
                }
                return Ok(ApiResponse.Success(result.Item2, "Login Successful!"));
            }
            catch (Exception)
            {
                return StatusCode(500, ApiResponse.Failure<string>(result.Item2));
            }

        }
    }
}
