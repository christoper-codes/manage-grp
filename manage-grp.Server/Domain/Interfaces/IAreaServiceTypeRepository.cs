using manage_grp.Server.DTOs;
using manage_grp.Server.Models;

namespace manage_grp.Server.Domain.Interfaces
{
    public interface IAreaServiceTypeRepository
    {
        Task<IEnumerable<AreaServiceType>> GetByAreaIdAsync(int areaId);

        Task<AreaServiceType?> GetByIdAsync(int id);

        Task<AreaServiceType?> CreateAsync(AreaServiceType areaServiceType, AreaServiceTypeDto areaServiceTypeDto);

        Task<bool?> UpdateAsync(AreaServiceType areaServiceType, AreaServiceTypeDto areaServiceTypeDto);

        Task<bool> DeleteAsync(AreaServiceType areaServiceType);
    }
}