using manage_grp.Server.DTOs;
using manage_grp.Server.Models;

namespace manage_grp.Server.Domain.Interfaces
{
    public interface IResourceDistributionRepository
    {
        Task<IEnumerable<ResourceDistribution>> GetByAreaAsync(int areaId);

        Task<ResourceDistribution?> GetByIdAsync(int id);

        Task<ResourceDistribution?> CreateAsync(ResourceDistribution resourceDistribution, ResourceDistributionDto resourceDistributionDto);

        Task<bool?> UpdateAsync(ResourceDistribution resourceDistribution, ResourceDistributionDto resourceDistributionDto);

        Task<bool> DeleteAsync(ResourceDistribution resourceDistribution);
    }
}