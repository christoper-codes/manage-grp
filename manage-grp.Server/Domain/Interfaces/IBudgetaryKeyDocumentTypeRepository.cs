
using manage_grp.Server.DTOs;
using manage_grp.Server.Models;

namespace manage_grp.Server.Repositories.Interfaces
{
    public interface IBudgetaryKeyDocumentTypeRepository
    {
        Task<BudgetaryKeyDocumentType?> GetByIdAsync(int id);
        
        Task<BudgetaryKeyDocumentType?> GetByKeysAsync(int budgetaryKeyId, int documentTypeById);

        Task<List<BudgetaryKeyDocumentType>> CreateListAsync(int budgetaryKeyId, List<BudgetaryKeyDocumentTypeDto> budgetaryKeyDocumentTypeDtos);

        Task<BudgetaryKeyDocumentType?> CreateAsync(BudgetaryKeyDocumentType budgetaryKeyDocumentType, BudgetaryKeyDocumentTypeDto budgetaryKeyDocumentTypeDto);
        
        Task<bool> DeleteAsync(BudgetaryKeyDocumentType budgetaryKeyDocumentType);
    }
}