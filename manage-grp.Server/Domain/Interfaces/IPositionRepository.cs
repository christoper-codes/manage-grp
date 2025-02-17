

using manage_grp.Server.DTOs;
using manage_grp.Server.Models;

namespace manage_grp.Server.Repositories.Interfaces
{
    public interface IPositionRepository
    {
        Task<IEnumerable<Position>> GetByDependencyIdAsync(int dependencyId);

        Task<Position?> GetByIdAsync(int id);

        Task<Position?> CreateAsync(Position position, PositionDto positionDto);

        Task<bool?> UpdateAsync(Position position, PositionDto positionDto);

        Task<bool> DeleteAsync(Position position);
    }
}

