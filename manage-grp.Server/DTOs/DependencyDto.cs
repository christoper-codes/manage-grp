namespace manage_grp.Server.DTOs
{
    public class DependencyDto
    {
        public int? Id { get; set; }

        public int MunicipalityId { get; set; }

        public string Name { get; set; }

        public string Acronym { get; set; }

        public string Rfc { get; set; }

        public bool IsActive { get; set; }
    }
}
