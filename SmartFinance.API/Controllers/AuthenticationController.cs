using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SmartFinance.Application.Contracts.Authentication;
using SmartFinance.Application.Contracts.Authentication.Dto;
using SmartFinance.Application.Contracts.Shared.Dto;

namespace SmartFinance.API.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _authenticationService;
        public AuthenticationController(IAuthService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [HttpPost("register")]
        public async Task<ActionResult<ApiResponse<object>>> Register(RegisterRequestDto dto)
        {
            try
            {
                await _authenticationService.RegisterAsync(dto);

                return StatusCode(201, ApiResponse<object>.Success(200, null));
            }
            catch (Exception ex)
            {
                return StatusCode(400, ApiResponse<object>.Failure(400, ex.Message));
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<ApiResponse<AuthResponseDto>>> Login(LoginRequestDto dto)
        {
            try
            {
                var result = await _authenticationService.LoginAsync(dto);

                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.None,
                    Expires = result.ExpiresAt
                };

                Response.Cookies.Append("access_token", result.AccessToken, cookieOptions);

                return Ok(ApiResponse<AuthResponseDto>.Success(200, result));
            }
            catch (Exception ex)
            {
                return StatusCode(400, ApiResponse<object>.Failure(400, ex.Message));
            }
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("access_token");
            return Ok(ApiResponse<object>.Success(200, "Logged out successfully"));
        }
    }
}
