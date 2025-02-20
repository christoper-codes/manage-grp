using manage_grp.Server.Domain.Interfaces;
using manage_grp.Server.Models;

namespace manage_grp.Server.Domain.Services
{
    public class MunicipalityService
    {
        private readonly IMunicipalityRepository _municipalityRepository;

        public MunicipalityService(IMunicipalityRepository municipalityRepository)
        {
            _municipalityRepository = municipalityRepository;
        }

        public async Task<IEnumerable<Municipality>> GetByStateIdAsync(int stateId)
        {
            try
            {
                return await _municipalityRepository.GetByStateIdAsync(stateId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Municipality?> GetByIdAsync(int id)
        {
            try
            {
                return await _municipalityRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task CreateListAsync(List<Municipality> municipalities)
        {
            try
            {
                await _municipalityRepository.CreateListAsync(municipalities);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
