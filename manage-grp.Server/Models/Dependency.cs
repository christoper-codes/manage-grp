using manage_grp.Server.Helpers;
using System.Text.Json.Serialization;

namespace manage_grp.Server.Models
{
    public class Dependency
    {
        public int? Id { get; set; }

        public Guid Uuid { get; set; } = Guid.NewGuid();

        public int MunicipalityId { get; set; }

        [JsonIgnore]
        public Municipality? Municipality { get; set; }

        public string Name { get; set; }

        public string Acronym { get; set; }

        public string Rfc { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; } = DateHelper.GetTimeInTimeZone();

        public DateTime UpdatedAt { get; set; } = DateHelper.GetTimeInTimeZone();

        [JsonIgnore]
        public ICollection<BudgetaryKey>? BudgetaryKeys { get; set; } = new List<BudgetaryKey>();

        [JsonIgnore]
        public ICollection<TenderFundingSource>? TenderFundingSources { get; set; } = new List<TenderFundingSource>();

        [JsonIgnore]
        public ICollection<TenderType>? TenderTypes { get; set; } = new List<TenderType>();

        [JsonIgnore]
        public ICollection<TenderStatus>? TenderStatuses { get; set; } = new List<TenderStatus>();

        [JsonIgnore]
        public ICollection<TenderPriceType>? TenderPriceTypes  { get; set; } = new List<TenderPriceType>();
    }
}
