using manage_grp.Server.DTOs;
using manage_grp.Server.Models;

namespace manage_grp.Server.Domain.Interfaces
{
    public interface IAreaRepository
    {
        Task<IEnumerable<Area>> GetByDependencyAsync(int dependencyId);

        Task<Area?> GetByIdAsync(int id);

        Task<Area?> CreateAsync(Area area, AreaDto areaDto);

        Task<bool?> UpdateAsync(Area area, AreaDto areaDto);

        Task<bool> DeleteAsync(Area area);
    }
}