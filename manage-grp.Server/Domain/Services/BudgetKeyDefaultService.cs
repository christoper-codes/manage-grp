using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using manage_grp.Server.Repositories.Interfaces;

namespace manage_grp.Server.Services
{
    public class BudgetKeyDefaultService
    {
        private readonly IBudgetKeyDefaultRepository _budgetKeyDefaultRepository;

        public BudgetKeyDefaultService(IBudgetKeyDefaultRepository budgetKeyDefaultRepository)
        {
            _budgetKeyDefaultRepository = budgetKeyDefaultRepository;
        }

        public async Task<IEnumerable<BudgetKeyDefault>> GetByDependencyIdAsync(int dependencyId)
        {
            try
            {
                return await _budgetKeyDefaultRepository.GetByDependencyIdAsync(dependencyId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BudgetKeyDefault?> GetByIdAsync(int id)
        {
            try
            {
                var budgetKeyDefault = await _budgetKeyDefaultRepository.GetByIdAsync(id);

                if (budgetKeyDefault == null)
                {
                    throw new KeyNotFoundException();
                }

                return budgetKeyDefault;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BudgetKeyDefault?> CreateAsync(BudgetKeyDefaultDto budgetKeyDefaultDto)
        {
            try
            {
                return await _budgetKeyDefaultRepository.CreateAsync(new BudgetKeyDefault(), budgetKeyDefaultDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        public async Task<bool?> UpdateAsync(int id, BudgetKeyDefaultDto budgetKeyDefaultDto)
        {
            try
            {
                var budgetKeyDefault = await GetByIdAsync(id);

                if (budgetKeyDefault == null)
                {
                    throw new KeyNotFoundException();
                }

                await _budgetKeyDefaultRepository.UpdateAsync(budgetKeyDefault, budgetKeyDefaultDto);

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
                var budgetKeyDefault = await _budgetKeyDefaultRepository.GetByIdAsync(id);

                if (budgetKeyDefault == null)
                {
                    throw new KeyNotFoundException();
                }

                return await _budgetKeyDefaultRepository.DeleteAsync(budgetKeyDefault);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}