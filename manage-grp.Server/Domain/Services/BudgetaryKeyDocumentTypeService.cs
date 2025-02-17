using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using manage_grp.Server.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace manage_grp.Server.Services
{
    public class BudgetaryKeyDocumentTypeService
    {
        private readonly IBudgetaryKeyDocumentTypeRepository _budgetaryKeyDocumentTypeRepository;
        private readonly IServiceProvider _serviceProvider;

        public BudgetaryKeyDocumentTypeService(IBudgetaryKeyDocumentTypeRepository budgetaryKeyDocumentTypeRepository, IServiceProvider serviceProvider)
        {
            _budgetaryKeyDocumentTypeRepository = budgetaryKeyDocumentTypeRepository;
            _serviceProvider = serviceProvider;
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
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<BudgetaryKeyDocumentType>> CreateListAsync(
            BudgetaryKey budgetaryKey,
            List<BudgetaryKeyDocumentTypeDto> budgetaryKeyDocumentTypesDto,
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
                        var budgetaryKeyDocumentType = budgetaryKeyDocumentTypes.FirstOrDefault(f => f.DocumentTypeId == budgetaryKeyDocumentTypeDto.DocumentTypeId);

                        budgetaryKeyDocumentTypeDto.DocumentRequirementDto!.BudgetaryKeyDocumentTypeId = (int)budgetaryKeyDocumentType!.Id!;

                        documentRequirementsDto.Add(budgetaryKeyDocumentTypeDto.DocumentRequirementDto);
                    }                    
                }

                if (documentRequirementsDto.Any())
                {
                    var dependency = await _serviceProvider.GetRequiredService<DependencyService>().GetByIdAsync(budgetaryKey.DependencyId);

                    await _serviceProvider.GetRequiredService<DocumentRequirementService>().CreateListAsync(
                        documentRequirementsDto,
                        FilePathGenerator.GeneratePathFromUuids([dependency!, budgetaryKey]),
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

        public async Task<bool> DeleteAsync(int budgetaryKeyId, int documentTypeById)
        {
            try
            {
                var budgetaryKeyDocumentType = await _budgetaryKeyDocumentTypeRepository.GetByKeysAsync(budgetaryKeyId, documentTypeById);

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
