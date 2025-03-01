using Microsoft.AspNetCore.Http;

namespace EcoStep.Shared.DTOs.Request.User;

public class UserVerifyCodeRequestDto
{
    public string? VerificationCode { get; set; } = default!;
    public string? Email { get; set; } = default!;
    public string? firebaseId { get; set; } = default!;
    

}