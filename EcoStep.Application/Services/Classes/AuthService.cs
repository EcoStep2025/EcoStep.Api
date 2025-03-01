using EcoStep.Application.Services.Interfaces;
using EcoStep.Application.Utilities.Mappers;
using EcoStep.Domain.Models;
using EcoStep.Infrastructure.Extensions.Claims.ServiceWrapper;
using EcoStep.Infrastructure.UnitOfWork;
using EcoStep.Shared.DTOs.Request.User;
using EcoStep.Shared.DTOs.Response.User;
using EcoStep.Shared.Result;
using FirebaseAdmin.Auth;
using Org.BouncyCastle.Asn1.Ocsp;
using System.CodeDom.Compiler;
using static Google.Apis.Requests.BatchRequest;


namespace EcoStep.Application.Services.Classes;

public class AuthService : IAuthService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserContext _userContext;
    private readonly IEmailService _emailService;

    public AuthService
    (
        IUnitOfWork unitOfWork,
        IUserContext userContext,
        IEmailService emailService

    )
    {
        _unitOfWork = unitOfWork;
        _userContext = userContext;
        _emailService = emailService;
    }

    public async Task<Result<UserCreateResponseDto>> CreateUserAsync(UserCreateRequestDto userCreateRequestDto,
        CancellationToken cancellationToken)
    {
        try
        {
            UserRecordArgs args = new UserRecordArgs
            {
                Email = userCreateRequestDto.Email,
                Password = userCreateRequestDto.Password,
            };

            UserRecord firebaseUser = await FirebaseAuth.DefaultInstance.CreateUserAsync(args, cancellationToken);

            if (firebaseUser != null)
            {
                userCreateRequestDto.FirebaseId = firebaseUser.Uid;
                User userToRegister = await _unitOfWork.UserRepository.Create(userCreateRequestDto.ToModel(), cancellationToken);
                string codigoConfirmacion = await _emailService.GenerateCode();

                userToRegister.VerificationCode = codigoConfirmacion;
                userToRegister.VerificationCodeExpiration = DateTime.UtcNow.AddMinutes(10);

                await _emailService.SendMailAsync(userCreateRequestDto.Email, codigoConfirmacion);


                await _unitOfWork.Complete(cancellationToken);

                var responseDto = userToRegister.ToResponse();

                return Result<UserCreateResponseDto>.Success(responseDto);
            }

            return Result<UserCreateResponseDto>.Failure("Error desconocido al crear el usuario en Firebase");
        }
        catch (FirebaseAuthException ex)
        {
            return Result<UserCreateResponseDto>.Failure($"Error de autenticación en Firebase: {ex.Message}");
        }
        catch (Exception ex)
        {
            return Result<UserCreateResponseDto>.Failure($"Error al crear el usuario: {ex.Message}");
        }
    }


    public async Task<Result<UserVerifyCodeResponseDto>> VerifyCodeAsync(UserVerifyCodeRequestDto userVerifyCodeRequestDto,
        CancellationToken cancellationToken)
    {
        User userInDb = await _unitOfWork.UserRepository.GetByEmail(userVerifyCodeRequestDto.Email);

        if (userInDb == null)
        {
            return Result<UserVerifyCodeResponseDto>.Failure($"El usuario no existe");
        }

        if (userInDb.VerificationCode != userVerifyCodeRequestDto.VerificationCode)
        {
            return Result<UserVerifyCodeResponseDto>.Failure($"El Codigo es Incorrecto");
        }

        if (userInDb.VerificationCodeExpiration < DateTime.UtcNow)
        {
            return Result<UserVerifyCodeResponseDto>.Failure($"El Codigo ha Expirado");
        }

        userInDb.isEmailVerified = true;
        userInDb.VerificationCode = null;
        userInDb.VerificationCodeExpiration = null;

        User userVerified = await _unitOfWork.UserRepository.Update(userInDb.Id, userInDb);

        await _unitOfWork.Complete(cancellationToken);
        var responseDto = userInDb.ToUserVerifyResponse();

        return Result<UserVerifyCodeResponseDto>.Success(responseDto);

    }




    public async Task<UserGetResponseDto> GetUserAsync(string firebaseId)
    {
        User? userInDb = await _unitOfWork.UserRepository.getUserByFirebaseId(firebaseId);

        UserGetResponseDto userGetResponseDto = userInDb.ToGetResponse();

        return userGetResponseDto;
    }

    public async Task<UserUpdateResponseDto> UpdateUserAsync(UserUpdateRequestDto userUpdateRequestDto,
        CancellationToken cancellationToken)
    {
        int userId = _userContext.GetUserId();

        return new UserUpdateResponseDto
        {
            Email = "test"
        };
    }
}
  