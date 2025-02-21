using System.Security;

using manage_grp.Server.Domain.Interfaces;
using manage_grp.Server.Enums;
using manage_grp.Server.Models;

namespace manage_grp.Server.Domain.Services
{
    public class PermissionService
    {
        private readonly IPermissionRepository _permissionRepository;

        public PermissionService(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        public async Task<List<Permission>> GetByHierarchyAsync(string hierarchyLevel)
        {
            List<Permission> permissions = await _permissionRepository.GetByHierarchyAsync(hierarchyLevel);

            var uniqueEntities = permissions.Select(d => d.Entity).Distinct().ToList();

            if (uniqueEntities.Any())
            {
                foreach (var entity in uniqueEntities)
                {
                    List<Permission> lisPermissions = await GetByHierarchyAsync(entity);

                    permissions.AddRange(lisPermissions);
                }
            }

            return permissions;
        }
    }
}