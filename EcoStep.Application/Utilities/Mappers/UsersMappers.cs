using EcoStep.Domain.Models;
using EcoStep.Shared.DTOs.Request.User;
using EcoStep.Shared.DTOs.Response.User;
using Org.BouncyCastle.Crypto;

namespace EcoStep.Application.Utilities.Mappers;

public static class UsersMappers
{
    public static User ToModel(this UserCreateRequestDto userCreateRequestDto)
    {
        return new User
        {
            FirebaseId = userCreateRequestDto.FirebaseId,
            Name = userCreateRequestDto.Name,
            LastName = userCreateRequestDto.LastName,
            Email = userCreateRequestDto.Email
        };
    }
    public static UserCreateResponseDto ToResponse (this User user)
    {
        return new UserCreateResponseDto
        {
            firebaseId = user.FirebaseId,
            name = user.Name,
            lastName = user.LastName,
            email = user.Email,
            isEmailVerified = user.isEmailVerified
        };
    }

    public static UserGetResponseDto ToGetResponse(this User user)
    {
        return new UserGetResponseDto
        {
            Id = user.Id,
            FirebaseId = user.FirebaseId,
            Name = user.Name,
            LastName = user.LastName,
            Email = user.Email,
            Address = user.Address,
            BirthDateTime = user.BirthDateTime,
            CountryName = user.Country?.CountryName,
            ProvinceName = user.Province?.ProvinceName,
            GenderName = user.Gender?.GenderName,


        };
    }

    public static UserVerifyCodeResponseDto ToUserVerifyResponse(this User user)
    {
        return new UserVerifyCodeResponseDto
        {
            Id = user.Id,
            isEmailVerified = user.isEmailVerified,
            token = user.Token

        };
    }


}