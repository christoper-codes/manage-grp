using manage_grp.Server.Helpers;
using System.Text.Json.Serialization;

namespace manage_grp.Server.Models
{
    public class Tender
    {              
        public int? Id { get; set; }

        public Guid Uuid { get; set; } = Guid.NewGuid();

        public int? AreaServiceTypeId { get; set; }

        [JsonIgnore]
        public AreaServiceType? AreaServiceType { get; set; }
        
        public int? TenderTypeId { get; set; }

        [JsonIgnore]
        public TenderType? TenderType { get; set; }

        public int? TenderStatusId { get; set; }

        [JsonIgnore]
        public TenderStatus? TenderStatus { get; set; }

        public int? TenderPriceTypeId { get; set; }

        [JsonIgnore]
        public TenderPriceType? TenderPriceType { get; set; }

        public int? TenderFundingSourceId { get; set; }

        [JsonIgnore]
        public TenderFundingSource? TenderFundingSource { get; set; }

        public string Key { get; set; }

        public string Name { get; set; }

        public string? Observation { get; set; }

        public DateTime PublicationDate { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateHelper.GetTimeInTimeZone();

        public DateTime UpdatedAt { get; set; } = DateHelper.GetTimeInTimeZone();

        [JsonIgnore]
        public ICollection<TenderDocumentTypeTender>? TenderDocumentTypeTenders { get; set; } = new List<TenderDocumentTypeTender>();

        [JsonIgnore]
        public ICollection<ResourceDistributionTender>? ResourceDistributionTenders { get; set; } = new List<ResourceDistributionTender>();

    }
}