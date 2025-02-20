using manage_grp.Server.Helpers;
using System.Text.Json.Serialization;

namespace manage_grp.Server.Models
{
    public class TenderDocumentType
    {
        public int? Id { get; set; }

        public int DependencyId { get; set; }

        [JsonIgnore]
        public Dependency? Dependency { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool Mandatory { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; } = DateHelper.GetTimeInTimeZone();

        public DateTime UpdatedAt { get; set; } = DateHelper.GetTimeInTimeZone();

        [JsonIgnore]
        public ICollection<TenderDocumentTypeTender>? TenderDocumentTypeTenders { get; set; } = new List<TenderDocumentTypeTender>();
    }
}