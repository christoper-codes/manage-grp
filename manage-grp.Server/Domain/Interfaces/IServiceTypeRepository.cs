using manage_grp.Server.DTOs;
using manage_grp.Server.Models;

namespace manage_grp.Server.Repositories.Interfaces
{
    public interface IServiceTypeRepository
    {
        Task<IEnumerable<ServiceType>> GetByAreaIdAsync(int areaId);

        Task<ServiceType?> GetByIdAsync(int id);

        Task<ServiceType?> CreateAsync(ServiceType serviceType, ServiceTypeDto serviceTypeDto);

        Task<bool?> UpdateAsync(ServiceType serviceType, ServiceTypeDto serviceTypeDto);

        Task<bool> DeleteAsync(ServiceType serviceType);
    }
}