using EcoStep.Application.Services.Interfaces;
using EcoStep.Shared.DTOs.Request.User;
using EcoStep.Shared.DTOs.Response.User;
using Microsoft.AspNetCore.Mvc;

namespace EcoStep.Api.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController
    (
        IAuthService authService
    )
    {
        _authService = authService;
    }
    [HttpPost]
    [Route("signup")]
    public async Task<IActionResult> CreateUser([FromBody] UserCreateRequestDto userCreateRequest, CancellationToken cancellationToken)
    {
        var response = await _authService.CreateUserAsync(userCreateRequest, cancellationToken);

        if (response.IsSuccess)
        {
            return StatusCode(201, response.Value);
        }

        return StatusCode(400, response.Error);
    }

    [HttpPost]
    [Route("verify-code")]
    public async Task<IActionResult> VerifyCode(UserVerifyCodeRequestDto userVerifyCodeRequestDto, CancellationToken cancellationToken)
    {
        var response = await _authService.VerifyCodeAsync(userVerifyCodeRequestDto, cancellationToken);

        if (response.IsSuccess)
        {
            return StatusCode(201, response.Value);
        }
        return BadRequest(response.Error);
    }




}