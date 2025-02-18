using manage_grp.Server.Data.Contexts;
using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using manage_grp.Server.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace manage_grp.Server.Repositories
{
    public class PriceTypeRepository : IPriceTypeRepository
    {
        private readonly AppDbContext _context;

        public PriceTypeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PriceType>> GetByDependencyAsync(int dependencyId)
        {
            return await _context.PriceTypes.Where(m => m.DependencyId == dependencyId).ToListAsync();
        }

        public async Task<PriceType?> GetByIdAsync(int id)
        {
            return await _context.PriceTypes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PriceType?> CreateAsync(PriceType priceType, PriceTypeDto priceTypeDto)
        {
            EntityHelper.UpdateEntityFromDto(Enums.UpdateEntityFromDtoAction.Create, priceType, priceTypeDto);

            _context.PriceTypes.Add(priceType);

            await _context.SaveChangesAsync();

            return priceType;
        }

        public async Task<bool?> UpdateAsync(PriceType priceType, PriceTypeDto priceTypeDto)
        {
            EntityHelper.UpdateEntityFromDto(Enums.UpdateEntityFromDtoAction.Update, priceType, priceTypeDto);

            _context.PriceTypes.Update(priceType);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(PriceType priceType)
        {
            _context.PriceTypes.Remove(priceType);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}