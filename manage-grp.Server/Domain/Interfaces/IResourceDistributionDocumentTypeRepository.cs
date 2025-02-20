using manage_grp.Server.DTOs;
using manage_grp.Server.Models;

namespace manage_grp.Server.Domain.Interfaces
{
    public interface IResourceDistributionDocumentTypeRepository
    {
        Task<IEnumerable<ResourceDistributionDocumentType>> GetByDependencyIdAsync(int dependencyId);

        Task<ResourceDistributionDocumentType?> GetByIdAsync(int id);

        Task<ResourceDistributionDocumentType?> CreateAsync(ResourceDistributionDocumentType tenderDocumentType, ResourceDistributionDocumentTypeDto tenderDocumentTypeDto);

        Task<bool?> UpdateAsync(ResourceDistributionDocumentType tenderDocumentType, ResourceDistributionDocumentTypeDto tenderDocumentTypeDto);

        Task<bool> DeleteAsync(ResourceDistributionDocumentType tenderDocumentType);
    }
}