using manage_grp.Server.Domain.Interfaces;
using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using manage_grp.Server.Services;

namespace manage_grp.Server.Domain.Services
{
    public class TenderService
    {
        private readonly ITenderRepository _tenderRepository;
        private readonly IServiceProvider _serviceProvider;

        public TenderService(ITenderRepository tenderRepository, IServiceProvider serviceProvider)
        {
            _tenderRepository = tenderRepository;
            _serviceProvider = serviceProvider;
        }

        public async Task<Tender?> GetByIdAsync(int id)
        {
            try
            {
                return await _tenderRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        public async Task<Tender?> CreateAsync(TenderDto tenderDto)
        {            
            try
            {
                var tender = await _tenderRepository.CreateAsync(new Tender(), tenderDto);

                if (tender != null)
                {
                    if (tenderDto.ResourceDistributionTendersDtos != null && tenderDto.ResourceDistributionTendersDtos.Any())
                    {
                        await _serviceProvider.GetRequiredService<ResourceDistributionTenderService>().CreateListAsync(tender, tenderDto.ResourceDistributionTendersDtos);
                    }

                    if (tenderDto.DocumentTypesDto != null && tenderDto.DocumentTypesDto.Any())
                    {
                        await _serviceProvider.GetRequiredService<TenderDocumentTypeTenderService>().CreateListAsync(
                            tender,
                            tenderDto.DocumentTypesDto,
                            tenderDto.FileGroupsDto,
                            tenderDto.FilesDto
                         );
                    }
                }                

                return tender;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool?> UpdateAsync(int id, TenderDto tenderDto)
        {
            try
            {
                var tender = await GetByIdAsync(id);

                if (tender == null)
                {
                    throw new KeyNotFoundException();
                }

                await _tenderRepository.UpdateAsync(tender, tenderDto);

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
                var tender = await _tenderRepository.GetByIdAsync(id);

                if (tender == null)
                {
                    throw new KeyNotFoundException();
                }

                return await _tenderRepository.DeleAsync(tender);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}