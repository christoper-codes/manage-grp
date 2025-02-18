using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using manage_grp.Server.Repositories.Interfaces;

namespace manage_grp.Server.Services
{
    public class PriceTypeService
    {
        private readonly IPriceTypeRepository _priceTypeRepository;

        public PriceTypeService(IPriceTypeRepository priceTypeRepository)
        {
            _priceTypeRepository = priceTypeRepository;
        }

        public async Task<IEnumerable<PriceType>> GetByDependencyAsync(int dependencyId)
        {
            try
            {
                return await _priceTypeRepository.GetByDependencyAsync(dependencyId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<PriceType?> GetByIdAsync(int id)
        {
            try
            {
                var priceType = await _priceTypeRepository.GetByIdAsync(id);

                if (priceType == null)
                {
                    throw new KeyNotFoundException();
                }

                return priceType;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PriceType?> CreateAsync(PriceTypeDto priceTypeDto)
        {
            try
            {
                return await _priceTypeRepository.CreateAsync(new PriceType(), priceTypeDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool?> UpdateAsync(int id, PriceTypeDto priceTypeDto)
        {
            try
            {
                var priceType = await GetByIdAsync(id);

                if (priceType == null)
                {
                    throw new KeyNotFoundException();
                }

                await _priceTypeRepository.UpdateAsync(priceType, priceTypeDto);

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
                var priceType = await _priceTypeRepository.GetByIdAsync(id);

                if (priceType == null)
                {
                    throw new KeyNotFoundException();
                }

                return await _priceTypeRepository.DeleteAsync(priceType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}