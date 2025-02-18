 using System.Text.Json.Serialization;
using manage_grp.Server.Helpers;

namespace manage_grp.Server.Models
{
    public class ResourceDistribution
    {
        public int? Id { get; set; }

        public int? BudgetaryKeyId { get; set; }

        [JsonIgnore]
        public BudgetaryKey? BudgetaryKey { get; set; }

        public int? AreaId { get; set; }

        [JsonIgnore]
        public Area? Area { get; set; }

        public int? ResourceTypeId { get; set; }

        [JsonIgnore]
        public ResourceType? ResourceType { get; set; }

        public string RequestNumber { get; set; }

        public string ResourceNumber { get; set; }

        public string Concept { get; set; }

        public decimal Amount { get; set; }

        public DateTime RequestDate { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string Observations { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateHelper.GetTimeInTimeZone();

        public DateTime UpdatedAt { get; set; } = DateHelper.GetTimeInTimeZone();

        [JsonIgnore]
        public ICollection<ResourceDistributionDocumentTypeResourceDistribution>? ResourceDistributionDocumentTypeResourceDistributions { get; set; } = new List<ResourceDistributionDocumentTypeResourceDistribution>();
    }
}