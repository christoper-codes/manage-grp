using manage_grp.Server.Helpers;
using System.Text.Json.Serialization;

namespace manage_grp.Server.Models
{
    public class Contact
    {
        public int? Id { get; set; }

        public int? DependencyId { get; set; }

        [JsonIgnore]
        public Dependency? Dependency { get; set; }

        public int? AreaId { get; set; }

        [JsonIgnore]
        public Area? Area { get; set; }

        public int PositionId { get; set; }

        [JsonIgnore]
        public Position? Position { get; set; }

        public string FirstName { get; set; }

        public string? MiddleName { get; set; }

        public string? PaternalLastName { get; set; }

        public string? MaternalLastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateHelper.GetTimeInTimeZone();

        public DateTime UpdatedAt { get; set; } = DateHelper.GetTimeInTimeZone();
    }
}