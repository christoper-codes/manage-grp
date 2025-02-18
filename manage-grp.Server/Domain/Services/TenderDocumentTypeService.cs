using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using manage_grp.Server.Repositories.Interfaces;

namespace manage_grp.Server.Services
{
    public class TenderDocumentTypeService
    {
        private readonly ITenderDocumentTypeRepository _tenderDocumentTypeRepository;

        public TenderDocumentTypeService(ITenderDocumentTypeRepository tenderDocumentTypeRepository)
        {
            _tenderDocumentTypeRepository = tenderDocumentTypeRepository;
        }

        public async Task<IEnumerable<TenderDocumentType>> GetByDependencyIdAsync(int dependencyId)
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

        public async Task<TenderDocumentType?> GetByIdAsync(int id)
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

        public async Task<TenderDocumentType?> CreateAsync(TenderDocumentTypeDto tenderDocumentTypeDto)
        {
            try
            {
                return await _tenderDocumentTypeRepository.CreateAsync(new TenderDocumentType(), tenderDocumentTypeDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool?> UpdateAsync(int id, TenderDocumentTypeDto tenderDocumentTypeDto)
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
