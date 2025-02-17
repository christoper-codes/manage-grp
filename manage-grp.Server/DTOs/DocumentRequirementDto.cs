namespace manage_grp.Server.DTOs
{
    public class DocumentRequirementDto
    {
        public int? Id { get; set; }

        public int BudgetaryKeyDocumentTypeId { get; set; }

        public string Purpose { get; set; }

        public string Description { get; set; }

        public int? Size { get; set; }

        public bool? IsActive { get; set; }
    }
}
