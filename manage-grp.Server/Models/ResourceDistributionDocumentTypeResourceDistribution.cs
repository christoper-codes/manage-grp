using manage_grp.Server.Helpers;
using System.Text.Json.Serialization;

namespace manage_grp.Server.Models
{
    public class ResourceDistributionDocumentTypeResourceDistribution
    {
        public int? Id { get; set; }

        public int ResourceDistributionId { get; set; }

        [JsonIgnore]
        public ResourceDistribution? ResourceDistribution { get; set; }

        public int ResourceDistributionDocumentTypeId { get; set; }

        [JsonIgnore]
        public ResourceDistributionDocumentType? ResourceDistributionDocumentType { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; } = DateHelper.GetTimeInTimeZone();

        public DateTime UpdatedAt { get; set; } = DateHelper.GetTimeInTimeZone();

        [JsonIgnore]
        public DocumentRequirement? DocumentRequirement { get; set; }
    }
}