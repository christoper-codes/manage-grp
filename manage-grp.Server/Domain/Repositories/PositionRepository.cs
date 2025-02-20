

using FluentValidation;
using manage_grp.Server.Data.Contexts;
using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using manage_grp.Server.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace manage_grp.Server.Domain.Repositories
{
    public class PositionRepository : IPositionRepository
    {
        private readonly AppDbContext _context;

        public PositionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Position>> GetByDependencyIdAsync(int dependencyId)
        {
            return await _context.Positions.Where(m => m.DependencyId == dependencyId).ToListAsync();
        }

        public async Task<Position?> GetByIdAsync(int id)
        {
            return await _context.Positions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Position?> CreateAsync(Position position, PositionDto positionDto)
        {
            EntityHelper.UpdateEntityFromDto(Enums.UpdateEntityFromDtoAction.Create, position, positionDto);

            _context.Positions.Add(position);

            await _context.SaveChangesAsync();

            return position;
        }

        public async Task<bool?> UpdateAsync(Position position, PositionDto positionDto)
        {
            EntityHelper.UpdateEntityFromDto(Enums.UpdateEntityFromDtoAction.Update, position, positionDto);

            _context.Positions.Update(position);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(Position position)
        {
            _context.Positions.Remove(position);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}