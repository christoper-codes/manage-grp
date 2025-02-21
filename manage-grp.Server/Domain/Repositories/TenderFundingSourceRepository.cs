using manage_grp.Server.Data.Contexts;
using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using manage_grp.Server.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace manage_grp.Server.Domain.Repositories
{
    public class TenderFundingSourceRepository : ITenderFundingSourceRepository
    {
        private readonly AppDbContext _context;

        public TenderFundingSourceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TenderFundingSource>> GetByDependencyAsync(int dependencyId)
        {
            return await _context.TenderFundingSources.Where(m => m.DependencyId == dependencyId).ToListAsync();
        }

        public async Task<TenderFundingSource?> GetByIdAsync(int id)
        {
            return await _context.TenderFundingSources.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TenderFundingSource?> CreateAsync(TenderFundingSource tenderFundingSource, TenderFundingSourceDto tenderFundingSourceDto)
        {
            EntityHelper.UpdateEntityFromDto(Enums.UpdateEntityFromDtoAction.Create, tenderFundingSource, tenderFundingSourceDto);

            _context.TenderFundingSources.Add(tenderFundingSource);

            await _context.SaveChangesAsync();

            return tenderFundingSource;
        }

        public async Task<bool?> UpdateAsync(TenderFundingSource tenderFundingSource, TenderFundingSourceDto tenderFundingSourceDto)
        {
            EntityHelper.UpdateEntityFromDto(Enums.UpdateEntityFromDtoAction.Update, tenderFundingSource, tenderFundingSourceDto);

            _context.TenderFundingSources.Update(tenderFundingSource);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(TenderFundingSource tenderFundingSource)
        {
            _context.TenderFundingSources.Remove(tenderFundingSource);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}