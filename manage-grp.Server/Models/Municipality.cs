using System.ComponentModel.DataAnnotations.Schema;

namespace manage_grp.Server.Models
{
    public class Municipality
    {
        // Properties

        public int? Id { get; set; }

        public int StateId { get; set; }
        public State? State { get; set; }

        public required string Name { get; set; }

        public string? Latitude { get; set; }

        public string? Longitude { get; set; }

        public string? Description { get; set; }

        public bool? IsActive { get; set; } = true;

        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; } = DateTime.Now;


        // Relationships

    }
}
