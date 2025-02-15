using Microsoft.AspNetCore.Mvc;

namespace manage_grp.Server.DTOs
{
    public class BudgetaryKeyDocumentTypeDto
    {
        public int? Id { get; set; }

        public int BudgetaryKeyId { get; set; }

        public int DocumentTypeId { get; set; }

        public bool? IsActive { get; set; }

        public DocumentRequirementDto? DocumentRequirementDto { get; set; }
    }
}
