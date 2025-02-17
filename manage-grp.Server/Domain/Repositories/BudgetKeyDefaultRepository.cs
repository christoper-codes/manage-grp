

using FluentValidation;
using manage_grp.Server.Data.Contexts;
using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using manage_grp.Server.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace manage_grp.Server.Repositories
{
    public class BudgetKeyDefaultRepository : IBudgetKeyDefaultRepository
    {
        private readonly AppDbContext _context;

        public BudgetKeyDefaultRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BudgetKeyDefault>> GetByDependencyIdAsync(int dependencyId)
        {
            return await _context.BudgetKeyDefaults.Where(m => m.DependencyId == dependencyId).ToListAsync();
        }

        public async Task<BudgetKeyDefault?> GetByIdAsync(int id)
        {
            return await _context.BudgetKeyDefaults.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<BudgetKeyDefault?> CreateAsync(BudgetKeyDefault budgetKeyDefault, BudgetKeyDefaultDto budgetKeyDefaultDto)
        {
            EntityHelper.UpdateEntityFromDto(Enums.UpdateEntityFromDtoAction.Create, budgetKeyDefault, budgetKeyDefaultDto);

            _context.BudgetKeyDefaults.Add(budgetKeyDefault);

            await _context.SaveChangesAsync();

            return budgetKeyDefault;
        }

        public async Task<bool?> UpdateAsync(BudgetKeyDefault budgetKeyDefault, BudgetKeyDefaultDto budgetKeyDefaultDto)
        {
            EntityHelper.UpdateEntityFromDto(Enums.UpdateEntityFromDtoAction.Update, budgetKeyDefault, budgetKeyDefaultDto);

            _context.BudgetKeyDefaults.Update(budgetKeyDefault);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(BudgetKeyDefault budgetKeyDefault)
        {
            _context.BudgetKeyDefaults.Remove(budgetKeyDefault);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}