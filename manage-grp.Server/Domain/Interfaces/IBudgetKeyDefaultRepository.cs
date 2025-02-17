
using manage_grp.Server.DTOs;
using manage_grp.Server.Models;

namespace manage_grp.Server.Repositories.Interfaces
{
    public interface IBudgetKeyDefaultRepository
    {
        Task<IEnumerable<BudgetKeyDefault>> GetByDependencyIdAsync(int dependencyId);

        Task<BudgetKeyDefault?> GetByIdAsync(int id);

        Task<BudgetKeyDefault?> CreateAsync(BudgetKeyDefault budgetKeyDefault, BudgetKeyDefaultDto budgetKeyDefaultDto);

        Task<bool?> UpdateAsync(BudgetKeyDefault budgetKeyDefault, BudgetKeyDefaultDto budgetKeyDefaultDto);

        Task<bool> DeleteAsync(BudgetKeyDefault budgetKeyDefault);
    }
}