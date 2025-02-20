using manage_grp.Server.Helpers;
using System.Text.Json.Serialization;

namespace manage_grp.Server.Models
{
    public class TenderDocumentTypeTender
    {
        public int? Id { get; set; }

        public int TenderId { get; set; }

        [JsonIgnore]
        public Tender Tender { get; set; }

        public int TenderDocumentTypeId { get; set; }

        [JsonIgnore]
        public TenderDocumentType TenderDocumentType { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateHelper.GetTimeInTimeZone();

        public DateTime UpdatedAt { get; set; } = DateHelper.GetTimeInTimeZone();

        [JsonIgnore]
        public DocumentRequirement? DocumentRequirement { get; set; }
    }
}