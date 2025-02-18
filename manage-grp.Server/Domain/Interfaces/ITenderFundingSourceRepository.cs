using manage_grp.Server.DTOs;
using manage_grp.Server.Models;

namespace manage_grp.Server.Repositories.Interfaces
{
    public interface ITenderFundingSourceRepository
    {
        Task<IEnumerable<TenderFundingSource>> GetByDependencyAsync(int dependencyId);

        Task<TenderFundingSource?> GetByIdAsync(int id);

        Task<TenderFundingSource?> CreateAsync(TenderFundingSource tenderFundingSource, TenderFundingSourceDto tenderFundingSourceDto);

        Task<bool?> UpdateAsync(TenderFundingSource tenderFundingSource, TenderFundingSourceDto tenderFundingSourceDto);

        Task<bool> DeleteAsync(TenderFundingSource tenderFundingSource);
    }
}