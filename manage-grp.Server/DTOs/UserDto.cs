namespace manage_grp.Server.DTOs
{
    public class UserDto
    {
        public int? Id { get; set; }

        public string? UserName { get; set; }

        public string? FirstName { get; set; }

        public string? MiddleName { get; set; }

        public string? PaternalLastName { get; set; }

        public string? MaternalLastName { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? PhoneNumber { get; set; }

        public int? DependencyId { get; set; }

        public int? MunicipalityId { get; set; }

        public int? StateId { get; set; }
    }
}
