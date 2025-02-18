using manage_grp.Server.Helpers;
using System.Text.Json.Serialization;

namespace manage_grp.Server.Models
{
    public class Municipality
    {
        public int? Id { get; set; }

        public string? ExternalMunicipalityId { get; set; }

        public int StateId { get; set; }

        [JsonIgnore]
        public State? State { get; set; }

        public string Name { get; set; }

        public string? Abbreviation { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateHelper.GetTimeInTimeZone();

        public DateTime UpdatedAt { get; set; } = DateHelper.GetTimeInTimeZone();

        [JsonIgnore]
        public ICollection<Dependency>? Dependencies { get; set; } = new List<Dependency>();
    }
}