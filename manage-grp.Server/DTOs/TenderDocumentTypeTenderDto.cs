namespace manage_grp.Server.DTOs
{
    public class TenderDocumentTypeTenderDto
    {
        public int? Id { get; set; }

        public int TenderId { get; set; }

        public int TenderDocumentTypeId { get; set; }

        public bool? IsActive { get; set; }

        public DocumentRequirementDto? DocumentRequirementDto { get; set; }
    }
}