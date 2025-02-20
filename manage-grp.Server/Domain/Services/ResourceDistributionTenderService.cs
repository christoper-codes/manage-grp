using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using manage_grp.Server.Domain.Interfaces;

namespace manage_grp.Server.Domain.Services
{
    public class ResourceDistributionTenderService
    {
        private readonly IResourceDistributionTenderRepository _resourceDistributionTenderRepository;

        public ResourceDistributionTenderService(IResourceDistributionTenderRepository resourceDistributionTenderRepository)
        {
            _resourceDistributionTenderRepository = resourceDistributionTenderRepository;
        }

        public async Task<ResourceDistributionTender?> GetByIdAsync(int id)
        {
            try
            {
                return await _resourceDistributionTenderRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResourceDistributionTender?> CreateAsync(ResourceDistributionTenderDto resourceDistributionTenderDto)
        {
            try
            {
                return await _resourceDistributionTenderRepository.CreateAsync(new ResourceDistributionTender(), resourceDistributionTenderDto);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ResourceDistributionTender>> CreateListAsync(Tender tender, List<ResourceDistributionTenderDto> resourceDistributionTendersDto){
            try
            {
                return await _resourceDistributionTenderRepository.CreateListAsync((int)tender.Id!, resourceDistributionTendersDto);               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteAsync(int tenderId, int resourceDistributionId)
        {
            try
            {
                var resourceDistributionTender = await _resourceDistributionTenderRepository.GetByKeysAsync(tenderId, resourceDistributionId);

                if (resourceDistributionTender == null)
                {
                    throw new KeyNotFoundException();
                }

                return await _resourceDistributionTenderRepository.DeleteAsync(resourceDistributionTender);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
