using manage_grp.Server.Data.Contexts;
using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using manage_grp.Server.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace manage_grp.Server.Repositories
{
    public class AreaRepository : IAreaRepository
    {
        private readonly AppDbContext _context;

        public AreaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Area>> GetByDependencyAsync(int dependencyId)
        {
            return await _context.Areas.Where(m => m.DependencyId == dependencyId).ToListAsync();
        }

        public async Task<Area?> GetByIdAsync(int id)
        {
            return await _context.Areas.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Area?> CreateAsync(Area area, AreaDto areaDto)
        {
            EntityHelper.UpdateEntityFromDto(Enums.UpdateEntityFromDtoAction.Create, area, areaDto);

            _context.Areas.Add(area);

            await _context.SaveChangesAsync();

            return area;
        }

        public async Task<bool?> UpdateAsync(Area area, AreaDto areaDto)
        {
            EntityHelper.UpdateEntityFromDto(Enums.UpdateEntityFromDtoAction.Update, area, areaDto);

            _context.Areas.Update(area);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(Area area)
        {
            _context.Areas.Remove(area);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}