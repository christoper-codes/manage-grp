using manage_grp.Server.Helpers;
using System.Text.Json.Serialization;

namespace manage_grp.Server.Models
{
    public class DocumentRequirement
    {
        public int? Id { get; set; }

        public int BudgetaryKeyDocumentTypeId { get; set; }

        [JsonIgnore]
        public BudgetaryKeyDocumentType? BudgetaryKeyDocumentType { get; set; }

        public string Purpose { get; set; }

        public string Description { get; set; }

        public int? Size { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateHelper.GetTimeInTimeZone();

        public DateTime UpdatedAt { get; set; } = DateHelper.GetTimeInTimeZone();
    }
}