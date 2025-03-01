using EcoStep.Shared.DTOs.Request.User;
using EcoStep.Shared.DTOs.Response.User;
using EcoStep.Shared.Result;

namespace EcoStep.Application.Services.Interfaces;

public interface IAuthService
{
    Task<UserUpdateResponseDto> UpdateUserAsync(UserUpdateRequestDto userUpdateRequestDto, CancellationToken cancellationToken);
    Task <Result<UserCreateResponseDto>> CreateUserAsync(UserCreateRequestDto userCreateRequestDto, CancellationToken cancellationToken);
    Task<UserGetResponseDto> GetUserAsync(string firebaseId);

    Task<Result<UserVerifyCodeResponseDto>> VerifyCodeAsync(UserVerifyCodeRequestDto userCreateRequestDto,
        CancellationToken cancellationToken);

}