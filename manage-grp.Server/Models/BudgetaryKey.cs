using manage_grp.Server.Helpers;
using System.Text.Json.Serialization;

namespace manage_grp.Server.Models
{
    public class BudgetaryKey
    {              
        public int? Id { get; set; }

        public Guid Uuid { get; set; } = Guid.NewGuid();

        public int DependencyId { get; set; }

        [JsonIgnore]
        public Dependency? Dependency { get; set; }

        public string Key { get; set; }

        public decimal Amount { get; set; }

        public string Concept { get; set; }

        public int ContactId { get; set; }

        [JsonIgnore]
        public Contact? Contact { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; } = DateHelper.GetTimeInTimeZone();

        public DateTime UpdatedAt { get; set; } = DateHelper.GetTimeInTimeZone();

        [JsonIgnore]
        public ICollection<BudgetaryKeyDocumentTypeBudgetaryKey>? BudgetaryKeyDocumentTypeBudgetaryKeys { get; set; } = new List<BudgetaryKeyDocumentTypeBudgetaryKey>();
    }
}