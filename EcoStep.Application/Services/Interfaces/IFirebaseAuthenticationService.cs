namespace EcoStep.Application.Services.Interfaces;

public interface IFirebaseAuthenticationService
{
    Task<string?> VerifyTokenAsync(string token);
}