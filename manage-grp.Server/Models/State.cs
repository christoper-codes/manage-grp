using manage_grp.Server.Helpers;
using System.Text.Json.Serialization;

namespace manage_grp.Server.Models
{
    public class State
    {
        public int? Id { get; set; }

        public string? ExternalStateId { get; set; }

        public string Name { get; set; }

        public string Abbreviation { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; } = DateHelper.GetTimeInTimeZone();

        public DateTime UpdatedAt { get; set; } = DateHelper.GetTimeInTimeZone();

        [JsonIgnore]
        public ICollection<Municipality>? Municipalities { get; set; } = new List<Municipality>();
    }
}
