

using FluentValidation;
using manage_grp.Server.Data.Contexts;
using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using manage_grp.Server.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace manage_grp.Server.Domain.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly AppDbContext _context;

        public DocumentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Document>> GetByDocumentRequirementAsync(int documentRequirementId)
        {
            return await _context.Documents.Where(m => m.DocumentRequirementId== documentRequirementId).ToListAsync();
        }

        public async Task<Document?> GetByIdAsync(int id)
        {
            return await _context.Documents.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Document>> CreateListAsync(List<Document> documents)
        {
            _context.Documents.AddRange(documents);

            await _context.SaveChangesAsync();

            return documents;
        }

        public async Task<Document?> CreateAsync(Document document, DocumentDto documentDto)
        {
            EntityHelper.UpdateEntityFromDto(Enums.UpdateEntityFromDtoAction.Create, document, documentDto);

            _context.Documents.Add(document);

            await _context.SaveChangesAsync();

            return document;
        }

        public async Task<bool?> UpdateAsync(Document document, DocumentDto documentDto)
        {
            EntityHelper.UpdateEntityFromDto(Enums.UpdateEntityFromDtoAction.Update, document, documentDto);

            _context.Documents.Update(document);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(Document document)
        {
            _context.Documents.Remove(document);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}