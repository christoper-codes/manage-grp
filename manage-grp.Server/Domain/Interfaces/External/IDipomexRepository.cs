
using manage_grp.Server.DTOs;
using manage_grp.Server.DTOs.External;

namespace manage_grp.Server.Domain.Interfaces.External
{
    public interface IDipomexRepository
    {
        Task<IEnumerable<StateDipomexDto>> GetAllStatesAsync(string url, string apiKey);

        Task<IEnumerable<MunicipalityDipomexDto>> GetAllMunicipalitiesByStateIdAsync(string url, string apiKey, string stateId);
    }
}