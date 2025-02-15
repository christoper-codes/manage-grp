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

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateHelper.GetTimeInTimeZone();

        public DateTime UpdatedAt { get; set; } = DateHelper.GetTimeInTimeZone();

        [JsonIgnore]
        public ICollection<BudgetaryKey>? BudgetaryKeys { get; set; } = new List<BudgetaryKey>();
    }
}
