using manage_grp.Server.Data.Contexts;
using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using manage_grp.Server.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace manage_grp.Server.Repositories
{
    public class TenderTypeRepository : ITenderTypeRepository
    {
        private readonly AppDbContext _context;

        public TenderTypeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TenderType>> GetByDependencyAsync(int dependencyId)
        {
            return await _context.TenderTypes.Where(m => m.DependencyId == dependencyId).ToListAsync();
        }

        public async Task<TenderType?> GetByIdAsync(int id)
        {
            return await _context.TenderTypes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TenderType?> CreateAsync(TenderType tenderType, TenderTypeDto tenderTypeDto)
        {
            EntityHelper.UpdateEntityFromDto(Enums.UpdateEntityFromDtoAction.Create, tenderType, tenderTypeDto);

            _context.TenderTypes.Add(tenderType);

            await _context.SaveChangesAsync();

            return tenderType;
        }

        public async Task<bool?> UpdateAsync(TenderType tenderType, TenderTypeDto tenderTypeDto)
        {
            EntityHelper.UpdateEntityFromDto(Enums.UpdateEntityFromDtoAction.Update, tenderType, tenderTypeDto);

            _context.TenderTypes.Update(tenderType);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(TenderType tenderType)
        {
            _context.TenderTypes.Remove(tenderType);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}