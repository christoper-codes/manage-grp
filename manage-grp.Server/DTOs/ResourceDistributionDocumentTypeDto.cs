namespace manage_grp.Server.DTOs
{
    public class ResourceDistributionDocumentTypeDto
    {
        public int? Id { get; set; }

        public int? DependencyId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool Mandatory { get; set; }

        public bool IsActive { get; set; }
    }
}