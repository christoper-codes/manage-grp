
using manage_grp.Server.DTOs;
using manage_grp.Server.Models;

namespace manage_grp.Server.Repositories.Interfaces
{
    public interface IAddressRepository
    {
        Task<IEnumerable<Address>> GetByDependencyAsync(int dependencyId);

        Task<Address?> GetByIdAsync(int id);

        Task<Address?> CreateAsync(Address address, AddressDto addressDto);

        Task<bool?> UpdateAsync(Address address, AddressDto addressDto);

        Task<bool> DeleteAsync(Address address);
    }
}