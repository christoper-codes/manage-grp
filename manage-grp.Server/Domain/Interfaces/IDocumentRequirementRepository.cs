
using manage_grp.Server.DTOs;
using manage_grp.Server.Models;

namespace manage_grp.Server.Repositories.Interfaces
{
    public interface IDocumentRequirementRepository
    {
        Task<IEnumerable<DocumentRequirement>> GetByBudgetaryKeyDocumentTypeIdAsync(int budgetaryKeyDocumentTypeId);

        Task<DocumentRequirement?> GetByIdAsync(int id);

        Task<List<DocumentRequirement>> CreateListAsync(List<DocumentRequirementDto> documentRequirementDto);

        Task<DocumentRequirement?> CreateAsync(DocumentRequirement documentRequirement, DocumentRequirementDto documentRequirementDto);

        Task<bool?> UpdateAsync(DocumentRequirement documentRequirement, DocumentRequirementDto documentRequirementDto);

        Task<bool> DeleteAsync(DocumentRequirement documentRequirement);
    }
}