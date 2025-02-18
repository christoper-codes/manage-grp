using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using manage_grp.Server.Repositories.Interfaces;

namespace manage_grp.Server.Services
{
    public class TenderFundingSourceService
    {
        private readonly ITenderFundingSourceRepository _tenderFundingSourceRepository;

        public TenderFundingSourceService(ITenderFundingSourceRepository tenderFundingSourceRepository)
        {
            _tenderFundingSourceRepository = tenderFundingSourceRepository;
        }

        public async Task<IEnumerable<TenderFundingSource>> GetByDependencyAsync(int dependencyId)
        {
            try
            {
                return await _tenderFundingSourceRepository.GetByDependencyAsync(dependencyId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<TenderFundingSource?> GetByIdAsync(int id)
        {
            try
            {
                return await _tenderFundingSourceRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TenderFundingSource?> CreateAsync(TenderFundingSourceDto tenderFundingSourceDto)
        {
            try
            {
                return await _tenderFundingSourceRepository.CreateAsync(new TenderFundingSource(), tenderFundingSourceDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool?> UpdateAsync(int id, TenderFundingSourceDto tenderFundingSourceDto)
        {
            try
            {
                var tenderFundingSource = await GetByIdAsync(id);

                if (tenderFundingSource == null)
                {
                    throw new KeyNotFoundException();
                }

                await _tenderFundingSourceRepository.UpdateAsync(tenderFundingSource, tenderFundingSourceDto);

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
                var tenderFundingSource = await _tenderFundingSourceRepository.GetByIdAsync(id);

                if (tenderFundingSource == null)
                {
                    throw new KeyNotFoundException();
                }

                return await _tenderFundingSourceRepository.DeleteAsync(tenderFundingSource);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}