using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using manage_grp.Server.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace manage_grp.Server.Services
{
    public class BudgetaryKeyDocumentTypeBudgetaryKeyService
    {
        private readonly IBudgetaryKeyDocumentTypeBudgetaryKeyRepository _budgetaryKeyDocumentTypeRepository;
        private readonly IServiceProvider _serviceProvider;

        public BudgetaryKeyDocumentTypeBudgetaryKeyService(IBudgetaryKeyDocumentTypeBudgetaryKeyRepository budgetaryKeyDocumentTypeRepository, IServiceProvider serviceProvider)
        {
            _budgetaryKeyDocumentTypeRepository = budgetaryKeyDocumentTypeRepository;
            _serviceProvider = serviceProvider;
        }

        public async Task<BudgetaryKeyDocumentTypeBudgetaryKey?> GetByIdAsync(int id)
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

        public async Task<BudgetaryKeyDocumentTypeBudgetaryKey?> CreateAsync(BudgetaryKeyDocumentTypeBudgetaryKeyDto budgetaryKeyDocumentTypeDto)
        {
            try
            {
                return await _budgetaryKeyDocumentTypeRepository.CreateAsync(new BudgetaryKeyDocumentTypeBudgetaryKey(), budgetaryKeyDocumentTypeDto);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<BudgetaryKeyDocumentTypeBudgetaryKey>> CreateListAsync(
            BudgetaryKey budgetaryKey,
            List<BudgetaryKeyDocumentTypeBudgetaryKeyDto> budgetaryKeyDocumentTypesDto,
            List<FileGroupDto> fileGroupsDto, 
            List<IFormFile> filesDto
         ){            
            try
            {
                var budgetaryKeyDocumentTypes =  await _budgetaryKeyDocumentTypeRepository.CreateListAsync((int)budgetaryKey.Id!, budgetaryKeyDocumentTypesDto);

                var documentRequirementsDto = new List<DocumentRequirementDto>();

                foreach (var budgetaryKeyDocumentTypeDto in budgetaryKeyDocumentTypesDto)
                {
                    if (budgetaryKeyDocumentTypeDto.DocumentRequirementDto != null)
                    {
                        var budgetaryKeyDocumentType = budgetaryKeyDocumentTypes.FirstOrDefault(f => f.BudgetaryKeyDocumentTypeId == budgetaryKeyDocumentTypeDto.BudgetaryKeyDocumentTypeId);

                        budgetaryKeyDocumentTypeDto.DocumentRequirementDto!.BudgetaryKeyDocumentTypeBudgetaryKeyId = (int)budgetaryKeyDocumentType!.Id!;

                        documentRequirementsDto.Add(budgetaryKeyDocumentTypeDto.DocumentRequirementDto);
                    }                    
                }

                if (documentRequirementsDto.Any())
                {
                    var dependency = await _serviceProvider.GetRequiredService<DependencyService>().GetByIdAsync(budgetaryKey.DependencyId);

                    await _serviceProvider.GetRequiredService<DocumentRequirementService>().CreateListAsync(
                        documentRequirementsDto,                        
                        FilePathGenerator.GeneratePathFromUuids([dependency!, budgetaryKey]),
                        f => f.BudgetaryKeyDocumentTypeBudgetaryKey,
                        b => b?.BudgetaryKeyDocumentTypeId,
                        fileGroupsDto,
                        filesDto
                     );
                }

                return budgetaryKeyDocumentTypes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteAsync(int budgetaryKeyId, int BudgetaryKeyDocumentTypeId)
        {
            try
            {
                var budgetaryKeyDocumentType = await _budgetaryKeyDocumentTypeRepository.GetByKeysAsync(budgetaryKeyId, BudgetaryKeyDocumentTypeId);

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
