using manage_grp.Server.Data.Contexts;
using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using manage_grp.Server.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace manage_grp.Server.Domain.Repositories
{
    public class ResourceTypeRepository : IResourceTypeRepository
    {
        private readonly AppDbContext _context;

        public ResourceTypeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ResourceType>> GetByDependencyIdAsync(int dependencyId)
        {
            return await _context.ResourceTypes.Where(m => m.DependencyId == dependencyId).ToListAsync();
        }

        public async Task<ResourceType?> GetByIdAsync(int id)
        {
            return await _context.ResourceTypes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ResourceType?> CreateAsync(ResourceType resourceType, ResourceTypeDto resourceTypeDto)
        {
            EntityHelper.UpdateEntityFromDto(Enums.UpdateEntityFromDtoAction.Create, resourceType, resourceTypeDto);

            _context.ResourceTypes.Add(resourceType);

            await _context.SaveChangesAsync();

            return resourceType;
        }

        public async Task<bool?> UpdateAsync(ResourceType resourceType, ResourceTypeDto resourceTypeDto)
        {
            EntityHelper.UpdateEntityFromDto(Enums.UpdateEntityFromDtoAction.Update, resourceType, resourceTypeDto);

            _context.ResourceTypes.Update(resourceType);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(ResourceType resourceType)
        {
            _context.ResourceTypes.Remove(resourceType);

            await _context.SaveChangesAsync();

            return true;
        }        
    }
}