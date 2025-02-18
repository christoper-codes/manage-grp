using manage_grp.Server.DTOs;
using manage_grp.Server.Models;

namespace manage_grp.Server.Repositories.Interfaces
{
    public interface IResourceDistributionDocumentTypeResourceDistributionRepository
    {
        Task<ResourceDistributionDocumentTypeResourceDistribution?> GetByIdAsync(int id);

        Task<ResourceDistributionDocumentTypeResourceDistribution?> GetByKeysAsync(int resourceDistributionId, int tenderDocumentTypeId);

        Task<List<ResourceDistributionDocumentTypeResourceDistribution>> CreateListAsync(int resourceDistributionId, List<ResourceDistributionDocumentTypeResourceDistributionDto> tenderDocumentTypeResourceDistributionDtos);

        Task<ResourceDistributionDocumentTypeResourceDistribution?> CreateAsync(ResourceDistributionDocumentTypeResourceDistribution tenderDocumentTypeResourceDistribution, ResourceDistributionDocumentTypeResourceDistributionDto tenderDocumentTypeResourceDistributionDto);

        Task<bool> DeleteAsync(ResourceDistributionDocumentTypeResourceDistribution tenderDocumentTypeResourceDistribution);
    }
}