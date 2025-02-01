namespace EcoStep.Domain.Models;

public class Event : BaseModel
{
    public string? Title { get; set; }
    public string? SmallDescription { get; set; }
    public string? LargeDescription { get; set; }
    public List<User>? UserId { get; set; }
    public int? CountryId { get; set; }
    public int? ProvinceId { get; set; }
    public List<int>? ImageId { get; set; }
    public DateTime? EventDate { get; set; }
    public string? Location { get; set; }
    public int? EventTypeId { get; set; }
    public int? TotalAttendees { get; set; }

    public virtual User? User { get; set; } 
    public virtual Country? Country { get; set; }
    public virtual Province?  Province { get; set; }
    public virtual Image? Image { get; set; }
    public virtual EventType? EventType { get; set; }
}