

using FluentValidation;
using manage_grp.Server.Data.Contexts;
using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using manage_grp.Server.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace manage_grp.Server.Repositories
{
    public class TenderDocumentTypeRepository : ITenderDocumentTypeRepository
    {
        private readonly AppDbContext _context;

        public TenderDocumentTypeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TenderDocumentType>> GetByDependencyIdAsync(int dependencyId)
        {
            return await _context.TenderDocumentTypes.Where(m => m.DependencyId == dependencyId).ToListAsync();
        }

        public async Task<TenderDocumentType?> GetByIdAsync(int id)
        {
            return await _context.TenderDocumentTypes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TenderDocumentType?> CreateAsync(TenderDocumentType tenderDocumentType, TenderDocumentTypeDto tenderDocumentTypeDto)
        {
            EntityHelper.UpdateEntityFromDto(Enums.UpdateEntityFromDtoAction.Create, tenderDocumentType, tenderDocumentTypeDto);

            _context.TenderDocumentTypes.Add(tenderDocumentType);

            await _context.SaveChangesAsync();

            return tenderDocumentType;
        }

        public async Task<bool?> UpdateAsync(TenderDocumentType tenderDocumentType, TenderDocumentTypeDto tenderDocumentTypeDto)
        {
            EntityHelper.UpdateEntityFromDto(Enums.UpdateEntityFromDtoAction.Update, tenderDocumentType, tenderDocumentTypeDto);

            _context.TenderDocumentTypes.Update(tenderDocumentType);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(TenderDocumentType tenderDocumentType)
        {
            _context.TenderDocumentTypes.Remove(tenderDocumentType);

            await _context.SaveChangesAsync();

            return true;
        }        
    }
}