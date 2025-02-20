using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using manage_grp.Server.Domain.Interfaces;

namespace manage_grp.Server.Domain.Services
{
    public class ResourceDistributionDocumentTypeService
    {
        private readonly IResourceDistributionDocumentTypeRepository _tenderDocumentTypeRepository;

        public ResourceDistributionDocumentTypeService(IResourceDistributionDocumentTypeRepository tenderDocumentTypeRepository)
        {
            _tenderDocumentTypeRepository = tenderDocumentTypeRepository;
        }

        public async Task<IEnumerable<ResourceDistributionDocumentType>> GetByDependencyIdAsync(int dependencyId)
        {
            try
            {
                return await _tenderDocumentTypeRepository.GetByDependencyIdAsync(dependencyId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResourceDistributionDocumentType?> GetByIdAsync(int id)
        {
            try
            {
                return await _tenderDocumentTypeRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResourceDistributionDocumentType?> CreateAsync(ResourceDistributionDocumentTypeDto tenderDocumentTypeDto)
        {
            try
            {
                return await _tenderDocumentTypeRepository.CreateAsync(new ResourceDistributionDocumentType(), tenderDocumentTypeDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool?> UpdateAsync(int id, ResourceDistributionDocumentTypeDto tenderDocumentTypeDto)
        {
            try
            {
                var tenderDocumentType = await GetByIdAsync(id);

                if (tenderDocumentType == null)
                {
                    throw new KeyNotFoundException();
                }

                await _tenderDocumentTypeRepository.UpdateAsync(tenderDocumentType, tenderDocumentTypeDto);

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
                var tenderDocumentType = await _tenderDocumentTypeRepository.GetByIdAsync(id);

                if (tenderDocumentType == null)
                {
                    throw new KeyNotFoundException();
                }

                return await _tenderDocumentTypeRepository.DeleteAsync(tenderDocumentType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
