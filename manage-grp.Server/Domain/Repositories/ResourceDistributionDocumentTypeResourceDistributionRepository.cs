using manage_grp.Server.Data.Contexts;
using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using manage_grp.Server.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace manage_grp.Server.Repositories
{
    public class ResourceDistributionDocumentTypeResourceDistributionRepository : IResourceDistributionDocumentTypeResourceDistributionRepository
    {
        private readonly AppDbContext _context;

        public ResourceDistributionDocumentTypeResourceDistributionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResourceDistributionDocumentTypeResourceDistribution?> GetByIdAsync(int id)
        {
            return await _context.ResourceDistributionDocumentTypeResourceDistributions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ResourceDistributionDocumentTypeResourceDistribution?> GetByKeysAsync(int resourceDistributionId, int tenderDocumentTypeResourceDistributionId)
        {
            return await _context.ResourceDistributionDocumentTypeResourceDistributions.FirstOrDefaultAsync(x => x.ResourceDistributionId == resourceDistributionId && x.ResourceDistributionDocumentTypeId == tenderDocumentTypeResourceDistributionId);
        }

        public async Task<List<ResourceDistributionDocumentTypeResourceDistribution>> CreateListAsync(int resourceDistributionId, List<ResourceDistributionDocumentTypeResourceDistributionDto> tenderDocumentTypeResourceDistributionDtos)
        {
            var tenderDocumentTypeResourceDistributions = tenderDocumentTypeResourceDistributionDtos.Select(dto => new ResourceDistributionDocumentTypeResourceDistribution
            {
                ResourceDistributionId = resourceDistributionId,
                ResourceDistributionDocumentTypeId = dto.ResourceDistributionDocumentTypeId
            }).ToList();

            _context.ResourceDistributionDocumentTypeResourceDistributions.AddRange(tenderDocumentTypeResourceDistributions);

            await _context.SaveChangesAsync();

            return tenderDocumentTypeResourceDistributions;
        }

        public async Task<ResourceDistributionDocumentTypeResourceDistribution?> CreateAsync(ResourceDistributionDocumentTypeResourceDistribution tenderDocumentTypeResourceDistribution, ResourceDistributionDocumentTypeResourceDistributionDto tenderDocumentTypeResourceDistributionDto)
        {
            EntityHelper.UpdateEntityFromDto(Enums.UpdateEntityFromDtoAction.Create, tenderDocumentTypeResourceDistribution, tenderDocumentTypeResourceDistributionDto);

            _context.ResourceDistributionDocumentTypeResourceDistributions.Add(tenderDocumentTypeResourceDistribution);

            await _context.SaveChangesAsync();

            return tenderDocumentTypeResourceDistribution;
        }

        public async Task<bool> DeleteAsync(ResourceDistributionDocumentTypeResourceDistribution tenderDocumentTypeResourceDistribution)
        {
            _context.ResourceDistributionDocumentTypeResourceDistributions.Remove(tenderDocumentTypeResourceDistribution);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}