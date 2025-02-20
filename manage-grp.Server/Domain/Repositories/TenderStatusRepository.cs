using manage_grp.Server.Data.Contexts;
using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using manage_grp.Server.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace manage_grp.Server.Domain.Repositories
{
    public class TenderStatusRepository : ITenderStatusRepository
    {
        private readonly AppDbContext _context;

        public TenderStatusRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TenderStatus>> GetByDependencyAsync(int dependencyId)
        {
            return await _context.TenderStatuses.Where(m => m.DependencyId == dependencyId).ToListAsync();
        }

        public async Task<TenderStatus?> GetByIdAsync(int id)
        {
            return await _context.TenderStatuses.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TenderStatus?> CreateAsync(TenderStatus tenderStatus, TenderStatusDto tenderStatusDto)
        {
            EntityHelper.UpdateEntityFromDto(Enums.UpdateEntityFromDtoAction.Create, tenderStatus, tenderStatusDto);

            _context.TenderStatuses.Add(tenderStatus);

            await _context.SaveChangesAsync();

            return tenderStatus;
        }

        public async Task<bool?> UpdateAsync(TenderStatus tenderStatus, TenderStatusDto tenderStatusDto)
        {
            EntityHelper.UpdateEntityFromDto(Enums.UpdateEntityFromDtoAction.Update, tenderStatus, tenderStatusDto);

            _context.TenderStatuses.Update(tenderStatus);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(TenderStatus tenderStatus)
        {
            _context.TenderStatuses.Remove(tenderStatus);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}