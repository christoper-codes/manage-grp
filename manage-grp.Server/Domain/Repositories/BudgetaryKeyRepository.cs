

using FluentValidation;
using manage_grp.Server.Data.Contexts;
using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using manage_grp.Server.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace manage_grp.Server.Domain.Repositories
{
    public class BudgetaryKeyRepository : IBudgetaryKeyRepository
    {
        private readonly AppDbContext _context;

        public BudgetaryKeyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BudgetaryKey>> GetByDependencyAsync(int dependencyId)
        {
            return await _context.BudgetaryKeys.Where(m => m.DependencyId == dependencyId).ToListAsync();
        }

        public async Task<BudgetaryKey?> GetByIdAsync(int id)
        {
            return await _context.BudgetaryKeys.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<BudgetaryKey?> CreateAsync(BudgetaryKey budgetaryKey, BudgetaryKeyDto budgetaryKeyDto)
        {
            EntityHelper.UpdateEntityFromDto(Enums.UpdateEntityFromDtoAction.Create, budgetaryKey, budgetaryKeyDto);

            _context.BudgetaryKeys.Add(budgetaryKey);

            await _context.SaveChangesAsync();

            return budgetaryKey;
        }

        public async Task<bool?> UpdateAsync(BudgetaryKey budgetaryKey, BudgetaryKeyDto budgetaryKeyDto)
        {
            EntityHelper.UpdateEntityFromDto(Enums.UpdateEntityFromDtoAction.Update, budgetaryKey, budgetaryKeyDto);

            _context.BudgetaryKeys.Update(budgetaryKey);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleAsync(BudgetaryKey budgetaryKey)
        {
            _context.BudgetaryKeys.Remove(budgetaryKey);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}