using manage_grp.Server.Data.Contexts;
using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using manage_grp.Server.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace manage_grp.Server.Domain.Repositories
{
    public class TenderPriceTypeRepository : ITenderPriceTypeRepository
    {
        private readonly AppDbContext _context;

        public TenderPriceTypeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TenderPriceType>> GetByDependencyAsync(int dependencyId)
        {
            return await _context.TenderPriceTypes.Where(m => m.DependencyId == dependencyId).ToListAsync();
        }

        public async Task<TenderPriceType?> GetByIdAsync(int id)
        {
            return await _context.TenderPriceTypes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TenderPriceType?> CreateAsync(TenderPriceType priceType, TenderPriceTypeDto priceTypeDto)
        {
            EntityHelper.UpdateEntityFromDto(Enums.UpdateEntityFromDtoAction.Create, priceType, priceTypeDto);

            _context.TenderPriceTypes.Add(priceType);

            await _context.SaveChangesAsync();

            return priceType;
        }

        public async Task<bool?> UpdateAsync(TenderPriceType priceType, TenderPriceTypeDto priceTypeDto)
        {
            EntityHelper.UpdateEntityFromDto(Enums.UpdateEntityFromDtoAction.Update, priceType, priceTypeDto);

            _context.TenderPriceTypes.Update(priceType);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(TenderPriceType priceType)
        {
            _context.TenderPriceTypes.Remove(priceType);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}