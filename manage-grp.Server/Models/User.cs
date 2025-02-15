using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace manage_grp.Server.Models
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }

        public string? MiddleName { get; set; }

        public string? PaternalLastName { get; set; }

        public string? MaternalLastName { get; set; }

        public int? StateId { get; set; }

        [JsonIgnore]
        public State? State { get; set; }

        public int? MunicipalityId { get; set; }

        [JsonIgnore]
        public Municipality? Municipality { get; set; }

        public int? DependencyId { get; set; }

        [JsonIgnore]
        public Dependency? Dependency { get; set; }
    }
}

