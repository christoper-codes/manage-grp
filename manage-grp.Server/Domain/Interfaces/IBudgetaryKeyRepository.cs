

using manage_grp.Server.DTOs;
using manage_grp.Server.Models;

namespace manage_grp.Server.Repositories.Interfaces
{
    public interface IBudgetaryKeyRepository
    {
        Task<IEnumerable<BudgetaryKey>> GetByDependencyAsync(int dependencyId);

        Task<BudgetaryKey?> GetByIdAsync(int id);

        Task<BudgetaryKey?> CreateAsync(BudgetaryKey budgetaryKey, BudgetaryKeyDto budgetaryKeyDto);

        Task<bool?> UpdateAsync(BudgetaryKey budgetaryKey, BudgetaryKeyDto budgetaryKeyDto);

        Task<bool> DeleAsync(BudgetaryKey budgetaryKey);
    }
}