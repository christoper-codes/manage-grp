using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using manage_grp.Server.Repositories.Interfaces;

namespace manage_grp.Server.Services
{
    public class TenderTypeService
    {
        private readonly ITenderTypeRepository _tenderTypeRepository;

        public TenderTypeService(ITenderTypeRepository tenderTypeRepository)
        {
            _tenderTypeRepository = tenderTypeRepository;
        }

        public async Task<IEnumerable<TenderType>> GetByDependencyAsync(int dependencyId)
        {
            try
            {
                return await _tenderTypeRepository.GetByDependencyAsync(dependencyId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<TenderType?> GetByIdAsync(int id)
        {
            try
            {
                var tenderType = await _tenderTypeRepository.GetByIdAsync(id);

                if (tenderType == null)
                {
                    throw new KeyNotFoundException();
                }

                return tenderType;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TenderType?> CreateAsync(TenderTypeDto tenderTypeDto)
        {
            try
            {
                return await _tenderTypeRepository.CreateAsync(new TenderType(), tenderTypeDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool?> UpdateAsync(int id, TenderTypeDto tenderTypeDto)
        {
            try
            {
                var tenderType = await GetByIdAsync(id);

                if (tenderType == null)
                {
                    throw new KeyNotFoundException();
                }

                await _tenderTypeRepository.UpdateAsync(tenderType, tenderTypeDto);

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
                var tenderType = await _tenderTypeRepository.GetByIdAsync(id);

                if (tenderType == null)
                {
                    throw new KeyNotFoundException();
                }

                return await _tenderTypeRepository.DeleteAsync(tenderType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}