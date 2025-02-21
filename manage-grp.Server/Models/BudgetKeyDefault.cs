using manage_grp.Server.Helpers;
using System.Text.Json.Serialization;

namespace manage_grp.Server.Models
{
    public class BudgetKeyDefault
    {
        public int? Id { get; set; }

        public int DependencyId { get; set; }

        [JsonIgnore]
        public Dependency? Dependency { get; set; }

        public string Key { get; set; }

        public string? Description { get; set; }

        public bool IsActive { get; set; }

        public bool Mandatory { get; set; }

        public DateTime CreatedAt { get; set; } = DateHelper.GetTimeInTimeZone();

        public DateTime UpdatedAt { get; set; } = DateHelper.GetTimeInTimeZone();
    }
}