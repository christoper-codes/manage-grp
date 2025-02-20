using manage_grp.Server.Helpers;
using System.Text.Json.Serialization;

namespace manage_grp.Server.Models
{
    public class ResourceDistributionTender
    {
        public int? Id { get; set; }

        public int TenderId { get; set; }

        [JsonIgnore]
        public Tender? Tender { get; set; }

        public int ResourceDistributionId { get; set; }

        [JsonIgnore]
        public ResourceDistribution? ResourceDistribution { get; set; }

        public bool? IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateHelper.GetTimeInTimeZone();

        public DateTime UpdatedAt { get; set; } = DateHelper.GetTimeInTimeZone();
    }
}