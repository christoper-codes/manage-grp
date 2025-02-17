using manage_grp.Server.Data.Contexts;
using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using manage_grp.Server.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace manage_grp.Server.Repositories
{
    public class BudgetaryKeyDocumentTypeRepository : IBudgetaryKeyDocumentTypeRepository
    {
        private readonly AppDbContext _context;

        public BudgetaryKeyDocumentTypeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<BudgetaryKeyDocumentType?> GetByIdAsync(int id)
        {
            return await _context.BudgetaryKeyDocumentTypes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<BudgetaryKeyDocumentType?> GetByKeysAsync(int budgetaryKeyId, int documentTypeById)
        {
            return await _context.BudgetaryKeyDocumentTypes.FirstOrDefaultAsync(x => x.BudgetaryKeyId == budgetaryKeyId && x.DocumentTypeId == documentTypeById);
        }

        public async Task<List<BudgetaryKeyDocumentType>> CreateListAsync(int budgetaryKeyId, List<BudgetaryKeyDocumentTypeDto> budgetaryKeyDocumentTypeDtos)
        {
            var budgetaryKeyDocumentTypes = budgetaryKeyDocumentTypeDtos.Select(dto => new BudgetaryKeyDocumentType
            {
                BudgetaryKeyId = budgetaryKeyId,
                DocumentTypeId = dto.DocumentTypeId
            }).ToList();

            _context.BudgetaryKeyDocumentTypes.AddRange(budgetaryKeyDocumentTypes);

            await _context.SaveChangesAsync();

            return budgetaryKeyDocumentTypes;
        }

        public async Task<BudgetaryKeyDocumentType?> CreateAsync(BudgetaryKeyDocumentType budgetaryKeyDocumentType, BudgetaryKeyDocumentTypeDto budgetaryKeyDocumentTypeDto)
        {
            EntityHelper.UpdateEntityFromDto(Enums.UpdateEntityFromDtoAction.Create, budgetaryKeyDocumentType, budgetaryKeyDocumentTypeDto);

            _context.BudgetaryKeyDocumentTypes.Add(budgetaryKeyDocumentType);

            await _context.SaveChangesAsync();

            return budgetaryKeyDocumentType;
        }

        public async Task<bool> DeleteAsync(BudgetaryKeyDocumentType budgetaryKeyDocumentType)
        {
            _context.BudgetaryKeyDocumentTypes.Remove(budgetaryKeyDocumentType);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}