using manage_grp.Server.Models;

namespace manage_grp.Server.Domain.Interfaces
{
    public interface IStateRepository
    {
        Task<IEnumerable<State>> GetAllAsync();

        Task<State?> GetByIdAsync(int id);
    }
}
