using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using manage_grp.Server.Domain.Interfaces;

namespace manage_grp.Server.Domain.Services
{
    public class AreaService
    {
        private readonly IAreaRepository _areaRepository;

        public AreaService(IAreaRepository areaRepository)
        {
            _areaRepository = areaRepository;
        }

        public async Task<IEnumerable<Area>> GetByDependencyAsync(int dependencyId)
        {
            try
            {
                return await _areaRepository.GetByDependencyAsync(dependencyId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<Area?> GetByIdAsync(int id)
        {
            try
            {
                return await _areaRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Area?> CreateAsync(AreaDto areaDto)
        {
            try
            {
                return await _areaRepository.CreateAsync(new Area(), areaDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool?> UpdateAsync(int id, AreaDto areaDto)
        {
            try
            {
                var area = await GetByIdAsync(id);

                if (area == null)
                {
                    throw new KeyNotFoundException();
                }

                await _areaRepository.UpdateAsync(area, areaDto);

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
                var area = await _areaRepository.GetByIdAsync(id);

                if (area == null)
                {
                    throw new KeyNotFoundException();
                }

                return await _areaRepository.DeleteAsync(area);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}