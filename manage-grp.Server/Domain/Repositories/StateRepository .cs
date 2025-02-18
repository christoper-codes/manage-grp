using manage_grp.Server.Models;
using manage_grp.Server.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using manage_grp.Server.Data.Contexts;

namespace manage_grp.Server.Domain.Repositories
{
    public class StateRepository : IStateRepository
    {
        private readonly AppDbContext _context;

        public StateRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<State>> CreateListAsync(List<State> states)
        {
            _context.States.AddRange(states);

            await _context.SaveChangesAsync();

            return states;
        }

        public async Task<IEnumerable<State>> GetAllAsync()
        {
            return await _context.States.ToListAsync();
        }

        public async Task<State?> GetByIdAsync(int id)
        {
            return await _context.States.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
