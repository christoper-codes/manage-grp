using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using manage_grp.Server.Repositories.Interfaces;
using System.Collections.Generic;

namespace manage_grp.Server.Services
{
    public class DocumentRequirementService
    {
        private readonly IDocumentRequirementRepository _documentRequirementRepository;
        private readonly IServiceProvider _serviceProvider;

        public DocumentRequirementService(IDocumentRequirementRepository documentRequirementRepository, IServiceProvider serviceProvider)
        {
            _documentRequirementRepository = documentRequirementRepository;
            _serviceProvider = serviceProvider;
        }

        public async Task<IEnumerable<DocumentRequirement>> GetByBudgetaryKeyDocumentTypeBudgetaryKeyIdAsync(int budgetaryKeyDocumentTypeId)
        {
            try
            {
                return await _documentRequirementRepository.GetByBudgetaryKeyDocumentTypeBudgetaryKeyIdAsync(budgetaryKeyDocumentTypeId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DocumentRequirement?> GetByIdAsync(int id)
        {
            try
            {
                return await _documentRequirementRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        

        public async Task<DocumentRequirement?> CreateAsync(DocumentRequirementDto documentRequirementDto)
        {
            try
            {
                return await _documentRequirementRepository.CreateAsync(new DocumentRequirement(), documentRequirementDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        public async Task<List<DocumentRequirement>> CreateListAsync<T>(List<DocumentRequirementDto> documentRequirementDto, string path,
            Func<DocumentRequirement, T?> relationSelector, Func<T?, int?> idSelector, List<FileGroupDto> FileGroupsDto, List<IFormFile> FilesDto)
        {
            try
            {
                var documentRequirements = await _documentRequirementRepository.CreateListAsync(documentRequirementDto);

                if (FileGroupsDto != null && FileGroupsDto.Any() && FilesDto != null && FilesDto.Any())
                {
                    foreach (var FileGroupDto in FileGroupsDto)
                    {
                        var file = documentRequirements.FirstOrDefault(f => idSelector(relationSelector(f)) == FileGroupDto.Id);

                        if (file != null)
                        {
                            FileGroupDto.DocumentRequirementId = file.Id;
                        }
                    }

                    await _serviceProvider.GetRequiredService<DocumentService>().CreateListAsync(path, FileGroupsDto, FilesDto);
                }

                return documentRequirements;
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
                var documentRequirement = await _documentRequirementRepository.GetByIdAsync(id);

                if (documentRequirement == null)
                {
                    throw new KeyNotFoundException();
                }

                return await _documentRequirementRepository.DeleteAsync(documentRequirement);
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }
    }
}