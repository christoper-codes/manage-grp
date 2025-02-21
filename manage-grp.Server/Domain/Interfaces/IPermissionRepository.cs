using manage_grp.Server.Models;

namespace manage_grp.Server.Domain.Interfaces
{
    public interface IPermissionRepository
    {
        Task<List<Permission>> GetByHierarchyAsync(string hierarchyLevel);
    }
}