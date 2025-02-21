
using manage_grp.Server.DTOs;
using manage_grp.Server.Models;

namespace manage_grp.Server.Domain.Interfaces
{
    public interface IBudgetaryKeyDocumentTypeBudgetaryKeyRepository
    {
        Task<BudgetaryKeyDocumentTypeBudgetaryKey?> GetByIdAsync(int id);
        
        Task<BudgetaryKeyDocumentTypeBudgetaryKey?> GetByKeysAsync(int budgetaryKeyId, int BudgetaryKeyDocumentTypeId);

        Task<List<BudgetaryKeyDocumentTypeBudgetaryKey>> CreateListAsync(int budgetaryKeyId, List<BudgetaryKeyDocumentTypeBudgetaryKeyDto> budgetaryKeyDocumentTypeBudgetaryKeyDtos);

        Task<BudgetaryKeyDocumentTypeBudgetaryKey?> CreateAsync(BudgetaryKeyDocumentTypeBudgetaryKey budgetaryKeyDocumentTypeBudgetaryKey, BudgetaryKeyDocumentTypeBudgetaryKeyDto budgetaryKeyDocumentTypeBudgetaryKeyDto);
        
        Task<bool> DeleteAsync(BudgetaryKeyDocumentTypeBudgetaryKey BudgetaryKeyDocumentTypeBudgetaryKey);
    }
}