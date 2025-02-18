using manage_grp.Server.Data.Contexts;
using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using manage_grp.Server.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace manage_grp.Server.Repositories
{
    public class BudgetaryKeyDocumentTypeBudgetaryKeyRepository : IBudgetaryKeyDocumentTypeBudgetaryKeyRepository
    {
        private readonly AppDbContext _context;

        public BudgetaryKeyDocumentTypeBudgetaryKeyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<BudgetaryKeyDocumentTypeBudgetaryKey?> GetByIdAsync(int id)
        {
            return await _context.BudgetaryKeyDocumentTypeBudgetaryKeys.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<BudgetaryKeyDocumentTypeBudgetaryKey?> GetByKeysAsync(int budgetaryKeyId, int budgetaryKeyDocumentTypeBudgetaryKeyId)
        {
            return await _context.BudgetaryKeyDocumentTypeBudgetaryKeys.FirstOrDefaultAsync(x => x.BudgetaryKeyId == budgetaryKeyId && x.BudgetaryKeyDocumentTypeId == budgetaryKeyDocumentTypeBudgetaryKeyId);
        }

        public async Task<List<BudgetaryKeyDocumentTypeBudgetaryKey>> CreateListAsync(int budgetaryKeyId, List<BudgetaryKeyDocumentTypeBudgetaryKeyDto> budgetaryKeyDocumentTypeBudgetaryKeyDtos)
        {
            var budgetaryKeyDocumentTypeBudgetaryKeys = budgetaryKeyDocumentTypeBudgetaryKeyDtos.Select(dto => new BudgetaryKeyDocumentTypeBudgetaryKey
            {
                BudgetaryKeyId = budgetaryKeyId,
                BudgetaryKeyDocumentTypeId = dto.BudgetaryKeyDocumentTypeId
            }).ToList();

            _context.BudgetaryKeyDocumentTypeBudgetaryKeys.AddRange(budgetaryKeyDocumentTypeBudgetaryKeys);

            await _context.SaveChangesAsync();

            return budgetaryKeyDocumentTypeBudgetaryKeys;
        }

        public async Task<BudgetaryKeyDocumentTypeBudgetaryKey?> CreateAsync(BudgetaryKeyDocumentTypeBudgetaryKey budgetaryKeyDocumentTypeBudgetaryKey, BudgetaryKeyDocumentTypeBudgetaryKeyDto budgetaryKeyDocumentTypeBudgetaryKeyDto)
        {
            EntityHelper.UpdateEntityFromDto(Enums.UpdateEntityFromDtoAction.Create, budgetaryKeyDocumentTypeBudgetaryKey, budgetaryKeyDocumentTypeBudgetaryKeyDto);

            _context.BudgetaryKeyDocumentTypeBudgetaryKeys.Add(budgetaryKeyDocumentTypeBudgetaryKey);

            await _context.SaveChangesAsync();

            return budgetaryKeyDocumentTypeBudgetaryKey;
        }

        public async Task<bool> DeleteAsync(BudgetaryKeyDocumentTypeBudgetaryKey budgetaryKeyDocumentTypeBudgetaryKey)
        {
            _context.BudgetaryKeyDocumentTypeBudgetaryKeys.Remove(budgetaryKeyDocumentTypeBudgetaryKey);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}