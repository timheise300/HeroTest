using System.Text.Json.Serialization;

namespace HeroTest.Models;

public partial class Brand
{
    public Brand()
    {
        Heroes = new HashSet<Hero>();
    }

    public int Id { get; set; } = 1;
    public string Name { get; set; } = null!;
    public bool? IsActive { get; set; }
    [JsonIgnore]
    public DateTime CreatedOn { get; set; }
    [JsonIgnore]
    public DateTime UpdatedOn { get; set; }
    [JsonIgnore]
    public virtual ICollection<Hero> Heroes { get; set; }
}
