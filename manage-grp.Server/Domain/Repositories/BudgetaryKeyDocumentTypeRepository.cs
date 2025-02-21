

using FluentValidation;
using manage_grp.Server.Data.Contexts;
using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using manage_grp.Server.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace manage_grp.Server.Domain.Repositories
{
    public class BudgetaryKeyDocumentTypeRepository : IBudgetaryKeyDocumentTypeRepository
    {
        private readonly AppDbContext _context;

        public BudgetaryKeyDocumentTypeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BudgetaryKeyDocumentType>> GetByDependencyIdAsync(int dependencyId)
        {
            return await _context.BudgetaryKeyDocumentTypes.Where(m => m.DependencyId == dependencyId).ToListAsync();
        }

        public async Task<BudgetaryKeyDocumentType?> GetByIdAsync(int id)
        {
            return await _context.BudgetaryKeyDocumentTypes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<BudgetaryKeyDocumentType?> CreateAsync(BudgetaryKeyDocumentType budgetaryKeyDocumentType, BudgetaryKeyDocumentTypeDto budgetaryKeyDocumentTypeDto)
        {
            EntityHelper.UpdateEntityFromDto(Enums.UpdateEntityFromDtoAction.Create, budgetaryKeyDocumentType, budgetaryKeyDocumentTypeDto);

            _context.BudgetaryKeyDocumentTypes.Add(budgetaryKeyDocumentType);

            await _context.SaveChangesAsync();

            return budgetaryKeyDocumentType;
        }

        public async Task<bool?> UpdateAsync(BudgetaryKeyDocumentType budgetaryKeyDocumentType, BudgetaryKeyDocumentTypeDto budgetaryKeyDocumentTypeDto)
        {
            EntityHelper.UpdateEntityFromDto(Enums.UpdateEntityFromDtoAction.Update, budgetaryKeyDocumentType, budgetaryKeyDocumentTypeDto);

            _context.BudgetaryKeyDocumentTypes.Update(budgetaryKeyDocumentType);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(BudgetaryKeyDocumentType budgetaryKeyDocumentType)
        {
            _context.BudgetaryKeyDocumentTypes.Remove(budgetaryKeyDocumentType);

            await _context.SaveChangesAsync();

            return true;
        }        
    }
}