namespace EcoStep.Domain.Models;

public class Community : BaseModel
{
    public string? Title { get; set; }
    public int? UserId { get; set; }
    public int? CountryId { get; set; }
    public int? ProvinceId { get; set; }
    public List<int>? ImageId { get; set; }





    public virtual User user { get; set; } = default!;
    public virtual Country country { get; set; } = default!;
    public virtual Province province{ get; set; } = default!;
    public virtual Image image { get; set; } = default!;

}