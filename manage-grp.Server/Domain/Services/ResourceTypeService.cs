using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using manage_grp.Server.Domain.Interfaces;

namespace manage_grp.Server.Domain.Services
{
    public class ResourceTypeService
    {
        private readonly IResourceTypeRepository _resourceTypeRepository;

        public ResourceTypeService(IResourceTypeRepository resourceTypeRepository)
        {
            _resourceTypeRepository = resourceTypeRepository;
        }

        public async Task<IEnumerable<ResourceType>> GetByDependencyIdAsync(int dependencyId)
        {
            try
            {
                return await _resourceTypeRepository.GetByDependencyIdAsync(dependencyId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResourceType?> GetByIdAsync(int id)
        {
            try
            {
                return await _resourceTypeRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResourceType?> CreateAsync(ResourceTypeDto resourceTypeDto)
        {
            try
            {
                return await _resourceTypeRepository.CreateAsync(new ResourceType(), resourceTypeDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool?> UpdateAsync(int id, ResourceTypeDto resourceTypeDto)
        {
            try
            {
                var resourceType = await GetByIdAsync(id);

                if (resourceType == null)
                {
                    throw new KeyNotFoundException();
                }

                await _resourceTypeRepository.UpdateAsync(resourceType, resourceTypeDto);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var resourceType = await _resourceTypeRepository.GetByIdAsync(id);

                if (resourceType == null)
                {
                    throw new KeyNotFoundException();
                }

                return await _resourceTypeRepository.DeleteAsync(resourceType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}