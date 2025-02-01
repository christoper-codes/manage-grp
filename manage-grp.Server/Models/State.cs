using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace manage_grp.Server.Models
{
    public class State
    {
        // Properties

        public int? Id { get; set; }

        public required string Name { get; set; }

        public required string Abbreviation { get; set; }

        public string? Description { get; set; }

        public Boolean? IsActive { get; set; } = true;

        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;


        // Relationships

        [JsonIgnore]
        public ICollection<Municipality>? Municipalities { get; set; }

    }
}
