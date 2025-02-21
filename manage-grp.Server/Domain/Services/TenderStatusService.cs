using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using manage_grp.Server.Domain.Interfaces;

namespace manage_grp.Server.Domain.Services
{
    public class TenderStatusService
    {
        private readonly ITenderStatusRepository _tenderStatusRepository;

        public TenderStatusService(ITenderStatusRepository tenderStatusRepository)
        {
            _tenderStatusRepository = tenderStatusRepository;
        }

        public async Task<IEnumerable<TenderStatus>> GetByDependencyAsync(int dependencyId)
        {
            try
            {
                return await _tenderStatusRepository.GetByDependencyAsync(dependencyId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<TenderStatus?> GetByIdAsync(int id)
        {
            try
            {
                return await _tenderStatusRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TenderStatus?> CreateAsync(TenderStatusDto tenderStatusDto)
        {
            try
            {
                return await _tenderStatusRepository.CreateAsync(new TenderStatus(), tenderStatusDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool?> UpdateAsync(int id, TenderStatusDto tenderStatusDto)
        {
            try
            {
                var tenderStatus = await GetByIdAsync(id);

                if (tenderStatus == null)
                {
                    throw new KeyNotFoundException();
                }

                await _tenderStatusRepository.UpdateAsync(tenderStatus, tenderStatusDto);

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
                var tenderStatus = await _tenderStatusRepository.GetByIdAsync(id);

                if (tenderStatus == null)
                {
                    throw new KeyNotFoundException();
                }

                return await _tenderStatusRepository.DeleteAsync(tenderStatus);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}