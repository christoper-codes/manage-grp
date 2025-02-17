using manage_grp.Server.Helpers;
using System.Text.Json.Serialization;

namespace manage_grp.Server.Models
{
    public class Document
    {
        public int? Id { get; set; }

        public int DocumentRequirementId { get; set; }

        [JsonIgnore]
        public DocumentRequirement? DocumentRequirement { get; set; }

        public string Name { get; set; }

        public string MimeType { get; set; }

        public long Size { get; set; }

        public byte[]? Content { get; set; }

        public string? Description { get; set; }

        public string Path { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateHelper.GetTimeInTimeZone();

        public DateTime UpdatedAt { get; set; } = DateHelper.GetTimeInTimeZone();
    }
}