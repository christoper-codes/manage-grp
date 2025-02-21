

using manage_grp.Server.DTOs;
using manage_grp.Server.Models;

namespace manage_grp.Server.Domain.Interfaces
{
    public interface IDependencyRepository
    {
        Task<IEnumerable<Dependency>> GetByMunicipalityIdAsync(int municipalityId);

        Task<Dependency?> GetByIdAsync(int id);

        Task<Dependency?> CreateAsync(Dependency dependency, DependencyDto dependencyDto);

        Task<bool?> UpdateAsync(Dependency dependency, DependencyDto dependencyDto);

        Task<bool> DeleteAsync(Dependency dependency);
    }
}

