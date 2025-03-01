using EcoStep.Domain.Enums;

namespace EcoStep.Domain.Models;

public class User : BaseModel
{
    public string FirebaseId { get; set; } = default!;
    public string? Name { get; set; }
    public string? LastName { get; set; }
    //public string? NickName { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime? BirthDateTime { get; set; }
    public int? GenderId { get; set; }
    public int? CountryId { get; set; }
    public int? ProvinceId { get; set; }
    public int? ImageId { get; set; }
    public string? VerificationCode { get; set; }
    public string? Token { get; set; }
    public bool? isEmailVerified { get; set; }
    public DateTime? VerificationCodeExpiration { get; set; }
    public RegisterType RegisterType { get; set; }


    #region Navigation Properties

    public virtual Country? Country { get; set; }   
    public virtual Gender? Gender { get; set; }
    public virtual Province? Province { get; set; }
    public virtual Image? Image{ get; set; }

    
    #endregion


}