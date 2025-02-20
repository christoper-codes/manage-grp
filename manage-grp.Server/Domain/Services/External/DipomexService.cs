using manage_grp.Server.Domain.Interfaces.External;
using manage_grp.Server.DTOs;
using manage_grp.Server.DTOs.External;
using manage_grp.Server.Models;

namespace manage_grp.Server.Domain.Services.External
{
    public class DipomexService
    {
        private readonly IDipomexRepository _dipomexRepository;
        private readonly IServiceProvider _serviceProvider;
        private readonly string _getAllState;
        private readonly string _getAllMunicipality;
        private readonly string _apiKey;

        public DipomexService(IDipomexRepository dipomexRepository, IServiceProvider serviceProvider, IConfiguration configuration)
        {
            _dipomexRepository = dipomexRepository;
            _serviceProvider = serviceProvider;
            _getAllState = configuration["Dipomex:GetAllState"];
            _getAllMunicipality = configuration["Dipomex:GetAllMunicipality"];
            _apiKey = configuration["Dipomex:APIKEY"];
        }

        public async Task<IEnumerable<StateDipomexDto>> GetAllStatesAsync()
        {
            try
            {
                var getAllStates = await _dipomexRepository.GetAllStatesAsync(_getAllState, _apiKey);

                var states = getAllStates.Select(d => new State
                {
                    ExternalStateId = d.ESTADO_ID,
                    Name = d.ESTADO,
                    Abbreviation = d.EDO1,
                }).ToList();

                await _serviceProvider.GetRequiredService<StateService>().CreateListAsync(states);

                return getAllStates;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<IEnumerable<MunicipalityDipomexDto>> GetAllMunicipalitiesAsync()
        {
            try
            {
                var states = await _serviceProvider.GetRequiredService<StateService>().GetAllAsync();

                List<MunicipalityDipomexDto> allMunicipalities = new List<MunicipalityDipomexDto>();

                foreach (var state in states)
                {
                    var getAllMunicipalities = await _dipomexRepository.GetAllMunicipalitiesByStateIdAsync(_getAllMunicipality, _apiKey, state.ExternalStateId);

                    var municipalities = getAllMunicipalities.Select(m => new Municipality
                    {
                        ExternalMunicipalityId = m.ESTADO_ID+"-"+m.MUNICIPIO_ID,
                        Name = m.MUNICIPIO,
                        StateId = (int)state.Id!,
                    }).ToList();

                    await _serviceProvider.GetRequiredService<MunicipalityService>().CreateListAsync(municipalities);

                    allMunicipalities.AddRange(getAllMunicipalities);
                }

                return allMunicipalities;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
