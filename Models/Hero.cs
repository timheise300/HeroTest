using System.Text.Json.Serialization;

namespace HeroTest.Models;

public partial class Hero
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Alias { get; set; }
    public bool? IsActive { get; set; }
    [JsonIgnore]
    public DateTime CreatedOn { get; set; }
    [JsonIgnore]
    public DateTime UpdatedOn { get; set; }
    [JsonIgnore]
    public int BrandId { get; set; }
    public virtual Brand Brand { get; set; } = null!;
}
