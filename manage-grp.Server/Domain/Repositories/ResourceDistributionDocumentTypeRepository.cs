using FluentValidation;
using manage_grp.Server.Data.Contexts;
using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using manage_grp.Server.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace manage_grp.Server.Repositories
{
    public class ResourceDistributionDocumentTypeRepository : IResourceDistributionDocumentTypeRepository
    {
        private readonly AppDbContext _context;

        public ResourceDistributionDocumentTypeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ResourceDistributionDocumentType>> GetByDependencyIdAsync(int dependencyId)
        {
            return await _context.ResourceDistributionDocumentTypes.Where(m => m.DependencyId == dependencyId).ToListAsync();
        }

        public async Task<ResourceDistributionDocumentType?> GetByIdAsync(int id)
        {
            return await _context.ResourceDistributionDocumentTypes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ResourceDistributionDocumentType?> CreateAsync(ResourceDistributionDocumentType tenderDocumentType, ResourceDistributionDocumentTypeDto tenderDocumentTypeDto)
        {
            EntityHelper.UpdateEntityFromDto(Enums.UpdateEntityFromDtoAction.Create, tenderDocumentType, tenderDocumentTypeDto);

            _context.ResourceDistributionDocumentTypes.Add(tenderDocumentType);

            await _context.SaveChangesAsync();

            return tenderDocumentType;
        }

        public async Task<bool?> UpdateAsync(ResourceDistributionDocumentType tenderDocumentType, ResourceDistributionDocumentTypeDto tenderDocumentTypeDto)
        {
            EntityHelper.UpdateEntityFromDto(Enums.UpdateEntityFromDtoAction.Update, tenderDocumentType, tenderDocumentTypeDto);

            _context.ResourceDistributionDocumentTypes.Update(tenderDocumentType);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(ResourceDistributionDocumentType tenderDocumentType)
        {
            _context.ResourceDistributionDocumentTypes.Remove(tenderDocumentType);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}