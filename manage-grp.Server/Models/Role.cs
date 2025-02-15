using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace manage_grp.Server.Models
{
    public class Role : IdentityRole
    {
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
