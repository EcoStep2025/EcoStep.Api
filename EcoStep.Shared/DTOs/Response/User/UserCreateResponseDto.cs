namespace EcoStep.Shared.DTOs.Response.User;

public class UserCreateResponseDto
{
    public string? firebaseId { get; set; }
    public string? name { get; set; }
    public string? lastName { get; set; }
    public string? email { get; set; }
    public bool? isEmailVerified { get; set; }
}
