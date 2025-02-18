using manage_grp.Server.Helpers;
using System.Text.Json.Serialization;

namespace manage_grp.Server.Models
{
    public class ServiceType
    {
        public int? Id { get; set; }

        public int? AreaId { get; set; }

        [JsonIgnore]
        public Area? Area { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateHelper.GetTimeInTimeZone();

        public DateTime UpdatedAt { get; set; } = DateHelper.GetTimeInTimeZone();
    }
}