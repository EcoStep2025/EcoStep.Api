namespace EcoStep.Application.Services.Interfaces;

public interface IEmailService
{
    Task SendMailAsync(string deliverTo, string code);
    Task<string> GenerateCode();
}