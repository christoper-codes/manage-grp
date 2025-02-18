using manage_grp.Server.Data.Contexts;
using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using manage_grp.Server.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace manage_grp.Server.Repositories
{
    public class ResourceDistributionRepository : IResourceDistributionRepository
    {
        private readonly AppDbContext _context;

        public ResourceDistributionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ResourceDistribution>> GetByAreaAsync(int areaId)
        {
            return await _context.ResourceDistributions.Where(m => m.AreaId == areaId).ToListAsync();
        }

        public async Task<ResourceDistribution?> GetByIdAsync(int id)
        {
            return await _context.ResourceDistributions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ResourceDistribution?> CreateAsync(ResourceDistribution resourceDistribution, ResourceDistributionDto resourceDistributionDto)
        {
            EntityHelper.UpdateEntityFromDto(Enums.UpdateEntityFromDtoAction.Create, resourceDistribution, resourceDistributionDto);

            _context.ResourceDistributions.Add(resourceDistribution);

            await _context.SaveChangesAsync();

            return resourceDistribution;
        }

        public async Task<bool?> UpdateAsync(ResourceDistribution resourceDistribution, ResourceDistributionDto resourceDistributionDto)
        {
            EntityHelper.UpdateEntityFromDto(Enums.UpdateEntityFromDtoAction.Update, resourceDistribution, resourceDistributionDto);

            _context.ResourceDistributions.Update(resourceDistribution);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(ResourceDistribution resourceDistribution)
        {
            _context.ResourceDistributions.Remove(resourceDistribution);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}