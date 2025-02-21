
using manage_grp.Server.Data.Contexts;
using manage_grp.Server.Domain.Interfaces;
using manage_grp.Server.Enums;
using manage_grp.Server.Models;

using Microsoft.EntityFrameworkCore;

namespace manage_grp.Server.Domain.Repositories
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly AppDbContext _context;

        public PermissionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Permission>> GetByHierarchyAsync(string hierarchyLevel)
        {
            return await _context.Permissions.Where(p => p.AllowedHierarchyLevels.Contains(hierarchyLevel)).ToListAsync();
        }
    }
}