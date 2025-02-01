using manage_grp.Server.Dominian.Interfaces;
using manage_grp.Server.Models;

namespace manage_grp.Server.Dominian.Services
{
    public class MunicipalityService
    {
        private readonly IMunicipalityRepository _municipalityRepository;
        private readonly IStateRepository _stateRepository;

        public MunicipalityService(IMunicipalityRepository municipalityRepository, IStateRepository stateRepository)
        {
            _municipalityRepository = municipalityRepository;
            _stateRepository = stateRepository;
        }

        public IEnumerable<Municipality> GetAll()
        {
            return _municipalityRepository.GetAll();
        }

        public Municipality GetById(int id)
        {
            try
            {
                return _municipalityRepository.GetById(id);
            }
            catch
            {
                throw;
            }
        }

        public Municipality Save(Municipality municipality)
        {
            try
            {
                var state = _stateRepository.GetById(municipality.StateId);
                if (state == null)
                {
                    throw new Exception("Estado no encontrado");
                }
                return _municipalityRepository.Save(municipality);

            }
            catch
            {
                throw;
            }
        }

        public Municipality Update(int id, Municipality municipality)
        {
            try
            {
                var existingMunicipality = _municipalityRepository.GetById(id);
                if (existingMunicipality == null)
                {
                    throw new Exception("Municipio no encontrado");
                }
                municipality.UpdatedAt = DateTime.Now;
                _municipalityRepository.Update(id, municipality);
                return municipality;
            }
            catch
            {
                throw;
            }
        }

        public Municipality Delete(int id)
        {
            try
            {
                return _municipalityRepository.Delete(id);
            }
            catch
            {
                throw;
            }
        }
    }
}
