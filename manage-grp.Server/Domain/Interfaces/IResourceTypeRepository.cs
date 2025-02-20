using manage_grp.Server.DTOs;
using manage_grp.Server.Models;

namespace manage_grp.Server.Domain.Interfaces
{
    public interface IResourceTypeRepository
    {
        Task<IEnumerable<ResourceType>> GetByDependencyIdAsync(int dependencyId);

        Task<ResourceType?> GetByIdAsync(int id);

        Task<ResourceType?> CreateAsync(ResourceType resourceType, ResourceTypeDto resourceTypeDto);

        Task<bool?> UpdateAsync(ResourceType resourceType, ResourceTypeDto resourceTypeDto);

        Task<bool> DeleteAsync(ResourceType resourceType);
    }
}