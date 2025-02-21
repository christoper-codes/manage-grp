
using manage_grp.Server.DTOs;
using manage_grp.Server.Models;

namespace manage_grp.Server.Domain.Interfaces
{
    public interface IBudgetaryKeyDocumentTypeRepository
    {
        Task<IEnumerable<BudgetaryKeyDocumentType>> GetByDependencyIdAsync(int dependencyId);

        Task<BudgetaryKeyDocumentType?> GetByIdAsync(int id);

        Task<BudgetaryKeyDocumentType?> CreateAsync(BudgetaryKeyDocumentType address, BudgetaryKeyDocumentTypeDto budgetaryKeyDocumentTypeDto);

        Task<bool?> UpdateAsync(BudgetaryKeyDocumentType address, BudgetaryKeyDocumentTypeDto budgetaryKeyDocumentTypeDto);

        Task<bool> DeleteAsync(BudgetaryKeyDocumentType budgetaryKeyDocumentType);
    }
}