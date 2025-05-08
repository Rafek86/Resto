using MediatR;
using Microsoft.AspNetCore.Mvc;
using Resto.Application.Common.Interfaces.Services;
using Resto.Application.DTOs;

namespace Resto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        private readonly IAuthService _authService = authService;

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequset request)
        {
            await _authService.RegisterAsync(request);
            return Ok("Registration successful. Please check your email to confirm.");
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login([FromBody] LoginRequestDto request)
        {
            var result = await _authService.GetTokenAsync(request.email, request.password);
            return Ok(result);
        }

        [HttpPost("confirm-email")]
        public async Task<IActionResult> ConfirmEmail([FromBody] ConfirmEmailRequest request)
        {
            await _authService.ConfirmEmailAsync(request);
            return Ok("Email confirmed successfully.");
        }

        [HttpPost("send-reset-password-code")]
        public async Task<IActionResult> SendResetPasswordCode([FromBody] string email)
        {
            await _authService.SendResetPassowrdCodeAsync(email);
            return Ok("If the email is registered and confirmed, a reset code has been sent.");
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetpasswordRequest request)
        {
            await _authService.ResetPasswordAsync(request);
            return Ok("Password has been reset.");
        }
    }
}
