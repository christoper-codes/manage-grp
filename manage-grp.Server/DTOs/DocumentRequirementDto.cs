namespace manage_grp.Server.DTOs
{
    public class DocumentRequirementDto
    {
        public int? Id { get; set; }

        public int? BudgetaryKeyDocumentTypeBudgetaryKeyId { get; set; }

        public int? ResourceDistributionDocumentTypeResourceDistributionId { get; internal set; }
        
        public int? TenderDocumentTypeTenderId { get; internal set; }

        public string Purpose { get; set; }

        public string Description { get; set; }

        public int? Size { get; set; }

        public bool? IsActive { get; set; }

    }
}
