using manage_grp.Server.Domain.Interfaces;
using manage_grp.Server.DTOs;
using manage_grp.Server.Models;

namespace manage_grp.Server.Domain.Services
{
    public class TenderDocumentTypeTenderService
    {
        private readonly ITenderDocumentTypeTenderRepository _tenderDocumentTypeTenderRepository;
        private readonly IServiceProvider _serviceProvider;

        public TenderDocumentTypeTenderService(ITenderDocumentTypeTenderRepository tenderDocumentTypeTenderRepository, IServiceProvider serviceProvider)
        {
            _tenderDocumentTypeTenderRepository = tenderDocumentTypeTenderRepository;
            _serviceProvider = serviceProvider;
        }

        public async Task<TenderDocumentTypeTender?> GetByIdAsync(int id)
        {
            try
            {
                return await _tenderDocumentTypeTenderRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TenderDocumentTypeTender?> CreateAsync(TenderDocumentTypeTenderDto tenderDocumentTypeDto)
        {
            try
            {
                return await _tenderDocumentTypeTenderRepository.CreateAsync(new TenderDocumentTypeTender(), tenderDocumentTypeDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<TenderDocumentTypeTender>> CreateListAsync(
            Tender tender,
            List<TenderDocumentTypeTenderDto> tenderDocumentTypesDto,
            List<FileGroupDto> fileGroupsDto,
            List<IFormFile> filesDto
         )
        {
            try
            {
                var tenderDocumentTypeTenders = await _tenderDocumentTypeTenderRepository.CreateListAsync((int)tender.Id!, tenderDocumentTypesDto);

                var documentRequirementsDto = new List<DocumentRequirementDto>();

                foreach (var tenderDocumentTypeDto in tenderDocumentTypesDto)
                {
                    if (tenderDocumentTypeDto.DocumentRequirementDto != null)
                    {
                        var tenderDocumentType = tenderDocumentTypeTenders.FirstOrDefault(f => f.TenderDocumentTypeId == tenderDocumentTypeDto.TenderDocumentTypeId);

                        tenderDocumentTypeDto.DocumentRequirementDto!.TenderDocumentTypeTenderId = (int)tenderDocumentType!.Id!;

                        documentRequirementsDto.Add(tenderDocumentTypeDto.DocumentRequirementDto);
                    }
                }

                if (documentRequirementsDto.Any())
                {
                    await _serviceProvider.GetRequiredService<DocumentRequirementService>().CreateListAsync(
                        documentRequirementsDto,
                        FilePathGenerator.GeneratePathFromUuids([tender.AreaServiceType!.Area!.Dependency!, tender.AreaServiceType.Area!, tender]),
                        f => f.TenderDocumentTypeTender,
                        b => b?.TenderDocumentTypeId,
                        fileGroupsDto,
                        filesDto
                     );
                }

                return tenderDocumentTypeTenders;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteAsync(int tenderId, int tenderDocumentTypeId)
        {
            try
            {
                var tenderDocumentTypeTender = await _tenderDocumentTypeTenderRepository.GetByKeysAsync(tenderId, tenderDocumentTypeId);

                if (tenderDocumentTypeTender == null)
                {
                    throw new KeyNotFoundException();
                }

                return await _tenderDocumentTypeTenderRepository.DeleteAsync(tenderDocumentTypeTender);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}