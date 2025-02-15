using manage_grp.Server.Models;

namespace manage_grp.Server.Domain.Interfaces
{
    public interface IMunicipalityRepository
    {
        Task<IEnumerable<Municipality>> GetByStateIdAsync(int stateId);

        Task<Municipality?> GetByIdAsync(int id);
    }
}
