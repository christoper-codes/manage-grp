using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using manage_grp.Server.Domain.Interfaces;

namespace manage_grp.Server.Domain.Services
{
    public class ResourceDistributionService
    {
        private readonly IResourceDistributionRepository _resourceDistributionRepository;
        private readonly IServiceProvider _serviceProvider;

        public ResourceDistributionService(IResourceDistributionRepository resourceDistributionRepository, IServiceProvider serviceProvider)
        {
            _resourceDistributionRepository = resourceDistributionRepository;
            _serviceProvider = serviceProvider;
        }

        public async Task<IEnumerable<ResourceDistribution>> GetByAreaAsync(int areaId)
        {
            try
            {
                return await _resourceDistributionRepository.GetByAreaAsync(areaId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResourceDistribution?> GetByIdAsync(int id)
        {
            try
            {
                return await _resourceDistributionRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResourceDistribution?> CreateAsync(ResourceDistributionDto resourceDistributionDto)
        {
            try
            {
                var resourceDistribution = await _resourceDistributionRepository.CreateAsync(new ResourceDistribution(), resourceDistributionDto);

                if (resourceDistribution != null && resourceDistributionDto.DocumentTypesDto != null && resourceDistributionDto.DocumentTypesDto.Any())
                {
                    await _serviceProvider.GetRequiredService<ResourceDistributionDocumentTypeResourceDistributionService>().CreateListAsync(
                        resourceDistribution,
                        resourceDistributionDto.DocumentTypesDto,
                        resourceDistributionDto.FileGroupsDto,
                        resourceDistributionDto.FilesDto
                     );
                }

                return resourceDistribution;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool?> UpdateAsync(int id, ResourceDistributionDto resourceDistributionDto)
        {
            try
            {
                var resourceDistribution = await GetByIdAsync(id);

                if (resourceDistribution == null)
                {
                    throw new KeyNotFoundException();
                }

                await _resourceDistributionRepository.UpdateAsync(resourceDistribution, resourceDistributionDto);

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
                var resourceDistribution = await _resourceDistributionRepository.GetByIdAsync(id);

                if (resourceDistribution == null)
                {
                    throw new KeyNotFoundException();
                }

                return await _resourceDistributionRepository.DeleteAsync(resourceDistribution);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}