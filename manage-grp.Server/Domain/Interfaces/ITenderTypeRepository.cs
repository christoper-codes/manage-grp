using manage_grp.Server.DTOs;
using manage_grp.Server.Models;

namespace manage_grp.Server.Domain.Interfaces
{
    public interface ITenderTypeRepository
    {
        Task<IEnumerable<TenderType>> GetByDependencyAsync(int dependencyId);

        Task<TenderType?> GetByIdAsync(int id);

        Task<TenderType?> CreateAsync(TenderType tenderType, TenderTypeDto tenderTypeDto);

        Task<bool?> UpdateAsync(TenderType tenderType, TenderTypeDto tenderTypeDto);

        Task<bool> DeleteAsync(TenderType tenderType);
    }
}