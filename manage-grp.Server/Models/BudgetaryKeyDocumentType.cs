using manage_grp.Server.Helpers;
using manage_grp.Server.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace manage_grp.Server.Models
{
    public class BudgetaryKeyDocumentType
    {
        public int? Id { get; set; }

        public int BudgetaryKeyId { get; set; }

        [JsonIgnore]
        public BudgetaryKey BudgetaryKey { get; set; }

        public int DocumentTypeId { get; set; }

        [JsonIgnore]
        public DocumentType DocumentType { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateHelper.GetTimeInTimeZone();

        public DateTime UpdatedAt { get; set; } = DateHelper.GetTimeInTimeZone();

        [JsonIgnore]
        public DocumentRequirement? DocumentRequirement { get; set; }
    }
}