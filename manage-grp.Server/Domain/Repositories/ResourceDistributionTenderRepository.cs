using manage_grp.Server.Data.Contexts;
using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using manage_grp.Server.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace manage_grp.Server.Repositories
{
    public class ResourceDistributionTenderRepository : IResourceDistributionTenderRepository
    {
        private readonly AppDbContext _context;

        public ResourceDistributionTenderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResourceDistributionTender?> GetByIdAsync(int id)
        {
            return await _context.ResourceDistributionTenders.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ResourceDistributionTender?> GetByKeysAsync(int tenderId, int resourceDistributionTenderId)
        {
            return await _context.ResourceDistributionTenders.FirstOrDefaultAsync(x => x.TenderId == tenderId && x.ResourceDistributionId == resourceDistributionTenderId);
        }

        public async Task<List<ResourceDistributionTender>> CreateListAsync(int tenderId, List<ResourceDistributionTenderDto> resourceDistributionTenderDtos)
        {
            var resourceDistributionTenders = resourceDistributionTenderDtos.Select(dto => new ResourceDistributionTender
            {
                TenderId = tenderId,
                ResourceDistributionId = dto.ResourceDistributionId
            }).ToList();

            _context.ResourceDistributionTenders.AddRange(resourceDistributionTenders);

            await _context.SaveChangesAsync();

            return resourceDistributionTenders;
        }

        public async Task<ResourceDistributionTender?> CreateAsync(ResourceDistributionTender resourceDistributionTender, ResourceDistributionTenderDto resourceDistributionTenderDto)
        {
            EntityHelper.UpdateEntityFromDto(Enums.UpdateEntityFromDtoAction.Create, resourceDistributionTender, resourceDistributionTenderDto);

            _context.ResourceDistributionTenders.Add(resourceDistributionTender);

            await _context.SaveChangesAsync();

            return resourceDistributionTender;
        }

        public async Task<bool> DeleteAsync(ResourceDistributionTender resourceDistributionTender)
        {
            _context.ResourceDistributionTenders.Remove(resourceDistributionTender);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}