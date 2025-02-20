using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using manage_grp.Server.Domain.Interfaces;

namespace manage_grp.Server.Domain.Services
{
    public class AreaServiceTypeService
    {
        private readonly IAreaServiceTypeRepository _areaServiceTypeRepository;

        public AreaServiceTypeService(IAreaServiceTypeRepository areaServiceTypeRepository)
        {
            _areaServiceTypeRepository = areaServiceTypeRepository;
        }

        public async Task<IEnumerable<AreaServiceType>> GetByAreaIdAsync(int areaId)
        {
            try
            {
                return await _areaServiceTypeRepository.GetByAreaIdAsync(areaId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<AreaServiceType?> GetByIdAsync(int id)
        {
            try
            {
                return await _areaServiceTypeRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AreaServiceType?> CreateAsync(AreaServiceTypeDto areaServiceTypeDto)
        {
            try
            {
                return await _areaServiceTypeRepository.CreateAsync(new AreaServiceType(), areaServiceTypeDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool?> UpdateAsync(int id, AreaServiceTypeDto areaServiceTypeDto)
        {
            try
            {
                var areaServiceType = await GetByIdAsync(id);

                if (areaServiceType == null)
                {
                    throw new KeyNotFoundException();
                }

                await _areaServiceTypeRepository.UpdateAsync(areaServiceType, areaServiceTypeDto);

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
                var areaServiceType = await _areaServiceTypeRepository.GetByIdAsync(id);

                if (areaServiceType == null)
                {
                    throw new KeyNotFoundException();
                }

                return await _areaServiceTypeRepository.DeleteAsync(areaServiceType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}