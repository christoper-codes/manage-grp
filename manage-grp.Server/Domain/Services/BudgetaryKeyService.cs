using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using manage_grp.Server.Repositories.Interfaces;

namespace manage_grp.Server.Services
{
    public class BudgetaryKeyService
    {
        private readonly IBudgetaryKeyRepository _budgetaryKeyRepository;
        private readonly IServiceProvider _serviceProvider;

        public BudgetaryKeyService(IBudgetaryKeyRepository budgetaryKeyRepository, IServiceProvider serviceProvider)
        {
            _budgetaryKeyRepository = budgetaryKeyRepository;
            _serviceProvider = serviceProvider;
        }

        public async Task<IEnumerable<BudgetaryKey>> GetByDependencyAsync(int dependencyId)
        {
            try
            {
                return await _budgetaryKeyRepository.GetByDependencyAsync(dependencyId);
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        public async Task<BudgetaryKey?> GetByIdAsync(int id)
        {
            try
            {
                var budgetaryKey = await _budgetaryKeyRepository.GetByIdAsync(id);

                if (budgetaryKey == null)
                {
                    throw new KeyNotFoundException();
                }

                return budgetaryKey;
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        public async Task<BudgetaryKey?> CreateAsync(BudgetaryKeyDto budgetaryKeyDto)
        {            
            try
            {
                var budgetaryKey = await _budgetaryKeyRepository.CreateAsync(new BudgetaryKey(), budgetaryKeyDto);

                if (budgetaryKey != null && budgetaryKeyDto.DocumentTypesDto != null && budgetaryKeyDto.DocumentTypesDto.Any())
                {
                    await _serviceProvider.GetRequiredService<BudgetaryKeyDocumentTypeService>().CreateListAsync(
                        budgetaryKey,
                        budgetaryKeyDto.DocumentTypesDto,
                        budgetaryKeyDto.FileGroupsDto,
                        budgetaryKeyDto.FilesDto
                     );
                }

                return budgetaryKey;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<bool?> UpdateAsync(int id, BudgetaryKeyDto budgetaryKeyDto)
        {
            try
            {
                var budgetaryKey = await GetByIdAsync(id);

                if (budgetaryKey == null)
                {
                    throw new KeyNotFoundException();
                }

                await _budgetaryKeyRepository.UpdateAsync(budgetaryKey, budgetaryKeyDto);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }          
        }

        public async Task<bool> DeleAsync(int id)
        {
            try
            {
                var budgetaryKey = await _budgetaryKeyRepository.GetByIdAsync(id);

                if (budgetaryKey == null)
                {
                    throw new KeyNotFoundException();
                }

                return await _budgetaryKeyRepository.DeleAsync(budgetaryKey);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}