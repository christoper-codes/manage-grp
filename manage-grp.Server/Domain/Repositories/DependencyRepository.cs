

using FluentValidation;
using manage_grp.Server.Data.Contexts;
using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using manage_grp.Server.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace manage_grp.Server.Repositories
{
    public class DependencyRepository : IDependencyRepository
    {
        private readonly AppDbContext _context;

        public DependencyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Dependency>> GetByMunicipalityIdAsync(int municipalityId)
        {
            return await _context.Dependencies.Where(m => m.MunicipalityId == municipalityId).ToListAsync();
        }

        public async Task<Dependency?> GetByIdAsync(int id)
        {
            return await _context.Dependencies.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Dependency?> CreateAsync(Dependency dependency, DependencyDto dependencyDto)
        {
            EntityHelper.UpdateEntityFromDto(Enums.UpdateEntityFromDtoAction.Create, dependency, dependencyDto);

            _context.Dependencies.Add(dependency);

            await _context.SaveChangesAsync();

            return dependency;
        }

        public async Task<bool?> UpdateAsync(Dependency dependency, DependencyDto dependencyDto)
        {            
            EntityHelper.UpdateEntityFromDto(Enums.UpdateEntityFromDtoAction.Update, dependency, dependencyDto);

            _context.Dependencies.Update(dependency);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(Dependency dependency)
        {
            _context.Dependencies.Remove(dependency);

            await _context.SaveChangesAsync();

            return true;
        }

    }
}