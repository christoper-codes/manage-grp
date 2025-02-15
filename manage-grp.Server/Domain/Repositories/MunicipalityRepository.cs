using manage_grp.Server.Data.Contexts;
using manage_grp.Server.Domain.Interfaces;
using manage_grp.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace manage_grp.Server.Domain.Repositories
{
    public class MunicipalityRepository : IMunicipalityRepository
    {
        private readonly AppDbContext _context;

        public MunicipalityRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Municipality>> GetByStateIdAsync(int state_id)
        {
            return await _context.Municipalities.Where(m => m.StateId == state_id).ToListAsync();
        }

        public async Task<Municipality?> GetByIdAsync(int id)
        {
            return await _context.Municipalities.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
