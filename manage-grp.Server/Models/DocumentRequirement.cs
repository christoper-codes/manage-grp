using manage_grp.Server.Helpers;
using System.Text.Json.Serialization;

namespace manage_grp.Server.Models
{
    public class DocumentRequirement
    {
        public int? Id { get; set; }

        public int? BudgetaryKeyDocumentTypeBudgetaryKeyId { get; set; }

        [JsonIgnore]
        public BudgetaryKeyDocumentTypeBudgetaryKey? BudgetaryKeyDocumentTypeBudgetaryKey { get; set; }
        
        public int? ResourceDistributionDocumentTypeResourceDistributionId { get; set; }

        [JsonIgnore]
        public ResourceDistributionDocumentTypeResourceDistribution? ResourceDistributionDocumentTypeResourceDistribution { get; set; }

        public int? TenderDocumentTypeTenderId { get; set; }

        [JsonIgnore]
        public TenderDocumentTypeTender? TenderDocumentTypeTender { get; set; }

        public string Purpose { get; set; }

        public string Description { get; set; }

        public int? Size { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; } = DateHelper.GetTimeInTimeZone();

        public DateTime UpdatedAt { get; set; } = DateHelper.GetTimeInTimeZone();
    }
}