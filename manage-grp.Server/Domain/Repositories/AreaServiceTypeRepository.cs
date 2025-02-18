using manage_grp.Server.Data.Contexts;
using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using manage_grp.Server.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace manage_grp.Server.Repositories
{
    public class AreaServiceTypeRepository : IAreaServiceTypeRepository
    {
        private readonly AppDbContext _context;

        public AreaServiceTypeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AreaServiceType>> GetByAreaIdAsync(int areaId)
        {
            return await _context.AreaServiceTypes.Where(m => m.AreaId == areaId).ToListAsync();
        }

        public async Task<AreaServiceType?> GetByIdAsync(int id)
        {
            return await _context.AreaServiceTypes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<AreaServiceType?> CreateAsync(AreaServiceType areaServiceType, AreaServiceTypeDto areaServiceTypeDto)
        {
            EntityHelper.UpdateEntityFromDto(Enums.UpdateEntityFromDtoAction.Create, areaServiceType, areaServiceTypeDto);

            _context.AreaServiceTypes.Add(areaServiceType);

            await _context.SaveChangesAsync();

            return areaServiceType;
        }

        public async Task<bool?> UpdateAsync(AreaServiceType areaServiceType, AreaServiceTypeDto areaServiceTypeDto)
        {
            EntityHelper.UpdateEntityFromDto(Enums.UpdateEntityFromDtoAction.Update, areaServiceType, areaServiceTypeDto);

            _context.AreaServiceTypes.Update(areaServiceType);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(AreaServiceType areaServiceType)
        {
            _context.AreaServiceTypes.Remove(areaServiceType);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}