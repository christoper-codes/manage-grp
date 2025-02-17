namespace manage_grp.Server.DTOs
{
    public class ContactDto
    {
        public int? Id { get; set; }

        public int? DependencyId { get; set; }

        public int? AreaId { get; set; }

        public int PositionId { get; set; }

        public string FirstName { get; set; }

        public string? MiddleName { get; set; }

        public string? PaternalLastName { get; set; }

        public string? MaternalLastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public bool? IsActive { get; set; }
    }
}
