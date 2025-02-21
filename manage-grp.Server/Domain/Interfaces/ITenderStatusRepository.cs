using manage_grp.Server.DTOs;
using manage_grp.Server.Models;

namespace manage_grp.Server.Domain.Interfaces
{
    public interface ITenderStatusRepository
    {
        Task<IEnumerable<TenderStatus>> GetByDependencyAsync(int dependencyId);

        Task<TenderStatus?> GetByIdAsync(int id);

        Task<TenderStatus?> CreateAsync(TenderStatus tenderStatus, TenderStatusDto tenderStatusDto);

        Task<bool?> UpdateAsync(TenderStatus tenderStatus, TenderStatusDto tenderStatusDto);

        Task<bool> DeleteAsync(TenderStatus tenderStatus);
    }
}