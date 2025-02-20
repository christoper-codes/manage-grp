using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using manage_grp.Server.Domain.Interfaces;

namespace manage_grp.Server.Domain.Services
{
    public class BudgetaryKeyDocumentTypeService
    {
        private readonly IBudgetaryKeyDocumentTypeRepository _budgetaryKeyDocumentTypeRepository;

        public BudgetaryKeyDocumentTypeService(IBudgetaryKeyDocumentTypeRepository budgetaryKeyDocumentTypeRepository)
        {
            _budgetaryKeyDocumentTypeRepository = budgetaryKeyDocumentTypeRepository;
        }

        public async Task<IEnumerable<BudgetaryKeyDocumentType>> GetByDependencyIdAsync(int dependencyId)
        {
            try
            {
                return await _budgetaryKeyDocumentTypeRepository.GetByDependencyIdAsync(dependencyId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BudgetaryKeyDocumentType?> GetByIdAsync(int id)
        {
            try
            {
                return await _budgetaryKeyDocumentTypeRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BudgetaryKeyDocumentType?> CreateAsync(BudgetaryKeyDocumentTypeDto budgetaryKeyDocumentTypeDto)
        {
            try
            {
                return await _budgetaryKeyDocumentTypeRepository.CreateAsync(new BudgetaryKeyDocumentType(), budgetaryKeyDocumentTypeDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool?> UpdateAsync(int id, BudgetaryKeyDocumentTypeDto budgetaryKeyDocumentTypeDto)
        {
            try
            {
                var budgetaryKeyDocumentType = await GetByIdAsync(id);
           
                if (budgetaryKeyDocumentType == null)
                {
                    throw new KeyNotFoundException();
                }

                await _budgetaryKeyDocumentTypeRepository.UpdateAsync(budgetaryKeyDocumentType, budgetaryKeyDocumentTypeDto);

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
                var budgetaryKeyDocumentType = await _budgetaryKeyDocumentTypeRepository.GetByIdAsync(id);

                if (budgetaryKeyDocumentType == null)
                {
                    throw new KeyNotFoundException();
                }

                return await _budgetaryKeyDocumentTypeRepository.DeleteAsync(budgetaryKeyDocumentType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
