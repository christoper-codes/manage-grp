namespace manage_grp.Server.DTOs
{
    public class AddressDto
    {
        public int? Id { get; set; }

        public int? DependencyId { get; set; }

        public string Neighborhood { get; set; }

        public string Street { get; set; }

        public int ExteriorNumber { get; set; }

        public int? InteriorNumber { get; set; }

        public string PostalCode { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string? Reference { get; set; }

        public bool IsActive { get; set; }
    }
}
