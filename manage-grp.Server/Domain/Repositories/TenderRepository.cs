using manage_grp.Server.Data.Contexts;
using manage_grp.Server.Domain.Interfaces;
using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using Microsoft.EntityFrameworkCore;


namespace manage_grp.Server.Domain.Repositories
{
    public class TenderRepository : ITenderRepository
    {
        private readonly AppDbContext _context;

        public TenderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Tender?> GetByIdAsync(int id)
        {
            return await _context.Tenders.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Tender?> CreateAsync(Tender tender, TenderDto tenderDto)
        {
            EntityHelper.UpdateEntityFromDto(Enums.UpdateEntityFromDtoAction.Create, tender, tenderDto);

            _context.Tenders.Add(tender);

            await _context.SaveChangesAsync();

            await _context.Entry(tender).Reference(t => t.AreaServiceType).LoadAsync();

            if (tender.AreaServiceType != null)
            {
                await _context.Entry(tender.AreaServiceType).Reference(ast => ast.Area).LoadAsync();

                if (tender.AreaServiceType.Area != null)
                {
                    await _context.Entry(tender.AreaServiceType.Area).Reference(a => a.Dependency).LoadAsync();
                }
            }

            return tender;
        }

        public async Task<bool?> UpdateAsync(Tender tender, TenderDto tenderDto)
        {
            EntityHelper.UpdateEntityFromDto(Enums.UpdateEntityFromDtoAction.Update, tender, tenderDto);

            _context.Tenders.Update(tender);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleAsync(Tender tender)
        {
            _context.Tenders.Remove(tender);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}