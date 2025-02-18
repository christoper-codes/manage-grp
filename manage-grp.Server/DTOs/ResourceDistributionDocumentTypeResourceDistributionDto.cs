namespace manage_grp.Server.DTOs
{
    public class ResourceDistributionDocumentTypeResourceDistributionDto
    {
        public int? Id { get; set; }

        public int ResourceDistributionId { get; set; }

        public int ResourceDistributionDocumentTypeId { get; set; }

        public bool? IsActive { get; set; }

        public DocumentRequirementDto? DocumentRequirementDto { get; set; }
    }
}