using manage_grp.Server.DTOs;
using manage_grp.Server.Helpers;
using manage_grp.Server.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace manage_grp.Server.Models
{
    public class BudgetaryKeyDocumentTypeBudgetaryKey
    {
        public int? Id { get; set; }

        public int BudgetaryKeyId { get; set; }

        [JsonIgnore]
        public BudgetaryKey? BudgetaryKey { get; set; }

        public int BudgetaryKeyDocumentTypeId { get; set; }

        [JsonIgnore]
        public BudgetaryKeyDocumentType? BudgetaryKeyDocumentType { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; } = DateHelper.GetTimeInTimeZone();

        public DateTime UpdatedAt { get; set; } = DateHelper.GetTimeInTimeZone();

        [JsonIgnore]
        public DocumentRequirement? DocumentRequirement { get; set; }
    }
}