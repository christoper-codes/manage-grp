using Microsoft.AspNetCore.Mvc;

namespace manage_grp.Server.DTOs
{
    public class BudgetaryKeyDocumentTypeBudgetaryKeyDto
    {
        public int? Id { get; set; }

        public int BudgetaryKeyId { get; set; }

        public int BudgetaryKeyDocumentTypeId { get; set; }

        public bool? IsActive { get; set; }

        public DocumentRequirementDto? DocumentRequirementDto { get; set; }
    }
}
