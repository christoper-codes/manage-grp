using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using manage_grp.Server.Domain.Interfaces;

namespace manage_grp.Server.Domain.Services
{
    public class ResourceDistributionDocumentTypeResourceDistributionService
    {
        private readonly IResourceDistributionDocumentTypeResourceDistributionRepository _tenderDocumentTypeResourceDistributionRepository;
        private readonly IServiceProvider _serviceProvider;

        public ResourceDistributionDocumentTypeResourceDistributionService(IResourceDistributionDocumentTypeResourceDistributionRepository tenderDocumentTypeResourceDistributionRepository, IServiceProvider serviceProvider)
        {
            _tenderDocumentTypeResourceDistributionRepository = tenderDocumentTypeResourceDistributionRepository;
            _serviceProvider = serviceProvider;
        }

        public async Task<ResourceDistributionDocumentTypeResourceDistribution?> GetByIdAsync(int id)
        {
            try
            {
                return await _tenderDocumentTypeResourceDistributionRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResourceDistributionDocumentTypeResourceDistribution?> CreateAsync(ResourceDistributionDocumentTypeResourceDistributionDto tenderDocumentTypeDto)
        {
            try
            {
                return await _tenderDocumentTypeResourceDistributionRepository.CreateAsync(new ResourceDistributionDocumentTypeResourceDistribution(), tenderDocumentTypeDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ResourceDistributionDocumentTypeResourceDistribution>> CreateListAsync(
            ResourceDistribution resourceDistribution,
            List<ResourceDistributionDocumentTypeResourceDistributionDto> tenderDocumentTypesDto,
            List<FileGroupDto> fileGroupsDto,
            List<IFormFile> filesDto
         )
        {
            try
            {
                var tenderDocumentTypeResourceDistributions = await _tenderDocumentTypeResourceDistributionRepository.CreateListAsync((int)resourceDistribution.Id!, tenderDocumentTypesDto);

                var documentRequirementsDto = new List<DocumentRequirementDto>();

                foreach (var tenderDocumentTypeDto in tenderDocumentTypesDto)
                {
                    if (tenderDocumentTypeDto.DocumentRequirementDto != null)
                    {
                        var tenderDocumentTypeResourceDistribution = tenderDocumentTypeResourceDistributions.FirstOrDefault(f => f.ResourceDistributionDocumentTypeId == tenderDocumentTypeDto.ResourceDistributionDocumentTypeId);

                        tenderDocumentTypeDto.DocumentRequirementDto!.ResourceDistributionDocumentTypeResourceDistributionId = (int)tenderDocumentTypeResourceDistribution!.Id!;

                        documentRequirementsDto.Add(tenderDocumentTypeDto.DocumentRequirementDto);
                    }
                }

                if (documentRequirementsDto.Any())
                {
                    await _serviceProvider.GetRequiredService<DocumentRequirementService>().CreateListAsync(
                        documentRequirementsDto,
                        FilePathGenerator.GeneratePathFromUuids([resourceDistribution.Area!.Dependency!, resourceDistribution.BudgetaryKey!]),
                        f => f.ResourceDistributionDocumentTypeResourceDistribution,
                        t => t?.ResourceDistributionDocumentTypeId,
                        fileGroupsDto,
                        filesDto
                     );
                }

                return tenderDocumentTypeResourceDistributions;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteAsync(int resourceDistributionId, int tenderDocumentTypeId)
        {
            try
            {
                var tenderDocumentTypeResourceDistribution = await _tenderDocumentTypeResourceDistributionRepository.GetByKeysAsync(resourceDistributionId, tenderDocumentTypeId);

                if (tenderDocumentTypeResourceDistribution == null)
                {
                    throw new KeyNotFoundException();
                }

                return await _tenderDocumentTypeResourceDistributionRepository.DeleteAsync(tenderDocumentTypeResourceDistribution);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}