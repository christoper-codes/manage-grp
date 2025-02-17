

using FluentValidation;
using manage_grp.Server.Data.Contexts;
using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using manage_grp.Server.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace manage_grp.Server.Repositories
{
    public class DocumentTypeRepository : IDocumentTypeRepository
    {
        private readonly AppDbContext _context;

        public DocumentTypeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DocumentType>> GetByDependencyIdAsync(int dependencyId)
        {
            return await _context.DocumentTypes.Where(m => m.DependencyId == dependencyId).ToListAsync();
        }

        public async Task<DocumentType?> GetByIdAsync(int id)
        {
            return await _context.DocumentTypes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<DocumentType?> CreateAsync(DocumentType documentType, DocumentTypeDto documentTypeDto)
        {
            EntityHelper.UpdateEntityFromDto(Enums.UpdateEntityFromDtoAction.Create, documentType, documentTypeDto);

            _context.DocumentTypes.Add(documentType);

            await _context.SaveChangesAsync();

            return documentType;
        }

        public async Task<bool?> UpdateAsync(DocumentType documentType, DocumentTypeDto documentTypeDto)
        {
            EntityHelper.UpdateEntityFromDto(Enums.UpdateEntityFromDtoAction.Update, documentType, documentTypeDto);

            _context.DocumentTypes.Update(documentType);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(DocumentType documentType)
        {
            _context.DocumentTypes.Remove(documentType);

            await _context.SaveChangesAsync();

            return true;
        }        
    }
}