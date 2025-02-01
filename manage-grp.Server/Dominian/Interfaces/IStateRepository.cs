using manage_grp.Server.Models;

namespace manage_grp.Server.Dominian.Interfaces
{
    public interface IStateRepository
    {
        // Primaries methods for the repository interface
        IEnumerable<State> GetAll();
        State GetById(int id);
        State Save(State state);
        State Update(int id, State state);
        State Delete(int id);

        // Custom methods for the repository interface
    }
}
