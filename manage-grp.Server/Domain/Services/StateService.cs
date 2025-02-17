using manage_grp.Server.Domain.Interfaces;
using manage_grp.Server.Models;

namespace manage_grp.Server.Domain.Services
{
    public class StateService
    {
        private readonly IStateRepository _stateRepository;

        public StateService(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        public async Task<IEnumerable<State>> GetAllAsync()
        {
            try
            {
                return await _stateRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<State?> GetByIdAsync(int id)
        {
            try
            {
                var state = await _stateRepository.GetByIdAsync(id);

                if (state == null)
                {
                    throw new KeyNotFoundException();
                }

                return state;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
