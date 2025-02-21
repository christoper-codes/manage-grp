using System.Text.Json.Serialization;
using manage_grp.Server.Helpers;

namespace manage_grp.Server.Models
{
    public class Area
    {
        public int? Id { get; set; }

        public Guid Uuid { get; set; } = Guid.NewGuid();

        public int DependencyId { get; set; }

        [JsonIgnore]
        public Dependency? Dependency { get; set; }

        public string Name { get; set; }

        public string Acronym { get; set; }

        public string? Description { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; } = DateHelper.GetTimeInTimeZone();

        public DateTime UpdatedAt { get; set; } = DateHelper.GetTimeInTimeZone();

        [JsonIgnore]
        public ICollection<AreaServiceType>? AreaServiceTypes { get; set; } = new List<AreaServiceType>(); 
    }
}