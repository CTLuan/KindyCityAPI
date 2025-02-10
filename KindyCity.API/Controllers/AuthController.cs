using KindyCity.Application.Commands.Auth.Create;
using KindyCity.Application.Commands.AuthCommand.Update;
using KindyCity.Application.Queries.Auth;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KindyCity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Create")] 
        public async Task<IActionResult> CreateEmloyee([FromBody] CreateUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginQuery command)
        {
            var result = await _mediator.Send(command);

            //if (result.EmployeeId == Guid.Empty)
            //    return BadRequest("Username hoặc password không chính xác");
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordQuery query)
        {
            var result = await _mediator.Send(query);
            if (result is null)
                return BadRequest("Email không chưa được đăng ký");

            return Ok(result);
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordQuery query)
        {
            var result = await _mediator.Send(query);

            if (!result)
                return BadRequest();

            return Ok(result);
        }

        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenQuery query)
        {
            var result = await _mediator.Send(query);
            if (result is null)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
