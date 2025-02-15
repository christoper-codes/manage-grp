

using FluentValidation;
using manage_grp.Server.Data.Contexts;
using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using manage_grp.Server.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace manage_grp.Server.Repositories
{
    public class DocumentRequirementRepository : IDocumentRequirementRepository
    {
        private readonly AppDbContext _context;

        public DocumentRequirementRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DocumentRequirement>> GetByBudgetaryKeyDocumentTypeIdAsync(int budgetaryKeyDocumentTypeId)
        {
            return await _context.DocumentRequirements.Where(m => m.BudgetaryKeyDocumentTypeId == budgetaryKeyDocumentTypeId).ToListAsync();
        }

        public async Task<DocumentRequirement?> GetByIdAsync(int id)
        {
            return await _context.DocumentRequirements.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<DocumentRequirement>> CreateListAsync(List<DocumentRequirementDto> documentRequirementDto)
        {
            var documentRequirements = documentRequirementDto.Select(dto => new DocumentRequirement
            {
                BudgetaryKeyDocumentTypeId = dto.BudgetaryKeyDocumentTypeId,
                Purpose = dto.Purpose,
                Description = dto.Description,
                Size = dto.Size,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }).ToList();

            _context.DocumentRequirements.AddRange(documentRequirements);

            await _context.SaveChangesAsync();

            return documentRequirements;
        }

        public async Task<DocumentRequirement?> CreateAsync(DocumentRequirement documentRequirement, DocumentRequirementDto documentRequirementDto)
        {
            EntityHelper.UpdateEntityFromDto(Enums.UpdateEntityFromDtoAction.Create, documentRequirement, documentRequirementDto);

            _context.DocumentRequirements.Add(documentRequirement);

            await _context.SaveChangesAsync();

            return documentRequirement;
        }

        public async Task<bool?> UpdateAsync(DocumentRequirement documentRequirement, DocumentRequirementDto documentRequirementDto)
        {
            EntityHelper.UpdateEntityFromDto(Enums.UpdateEntityFromDtoAction.Update, documentRequirement, documentRequirementDto);

            _context.DocumentRequirements.Update(documentRequirement);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(DocumentRequirement documentRequirement)
        {
            _context.DocumentRequirements.Remove(documentRequirement);

            await _context.SaveChangesAsync();

            return true;
        }        
    }
}