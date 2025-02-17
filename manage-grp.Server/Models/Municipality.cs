using manage_grp.Server.Helpers;
using System.Text.Json.Serialization;

namespace manage_grp.Server.Models
{
    public class Municipality
    {
        public int? Id { get; set; }

        public int StateId { get; set; }

        [JsonIgnore]
        public State? State { get; set; }

        public string Name { get; set; }

        public int MunicipalityKey { get; set; }

        public string Abbreviation { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateHelper.GetTimeInTimeZone();

        public DateTime UpdatedAt { get; set; } = DateHelper.GetTimeInTimeZone();

        [JsonIgnore]
        public ICollection<Dependency>? Dependencies { get; set; } = new List<Dependency>();
    }
}