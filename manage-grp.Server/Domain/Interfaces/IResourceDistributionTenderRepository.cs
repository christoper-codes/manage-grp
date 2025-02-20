
using manage_grp.Server.DTOs;
using manage_grp.Server.Models;

namespace manage_grp.Server.Repositories.Interfaces
{
    public interface IResourceDistributionTenderRepository
    {
        Task<ResourceDistributionTender?> GetByIdAsync(int id);
        
        Task<ResourceDistributionTender?> GetByKeysAsync(int tenderId, int resourceDistributionId);

        Task<List<ResourceDistributionTender>> CreateListAsync(int tenderId, List<ResourceDistributionTenderDto> resourceDistributionTenderDtos);

        Task<ResourceDistributionTender?> CreateAsync(ResourceDistributionTender resourceDistributionTender, ResourceDistributionTenderDto resourceDistributionTenderDto);
        
        Task<bool> DeleteAsync(ResourceDistributionTender ResourceDistributionTender);
    }
}