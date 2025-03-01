using Microsoft.AspNetCore.Http;

namespace EcoStep.Shared.DTOs.Request.User;

public class UserCreateRequestDto
{
    public string? FirebaseId { get; set; } = default!;
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
}