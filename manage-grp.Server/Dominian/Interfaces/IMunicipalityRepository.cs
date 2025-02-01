using manage_grp.Server.Models;

namespace manage_grp.Server.Dominian.Interfaces
{
    public interface IMunicipalityRepository
    {
        // Primaries methods for the repository interface
        IEnumerable<Municipality> GetAll();
        Municipality GetById(int id);
        Municipality Save(Municipality municipality);
        Municipality Update(int id, Municipality municipality);
        Municipality Delete(int id);

        // Custom methods for the repository interface
    }
}
