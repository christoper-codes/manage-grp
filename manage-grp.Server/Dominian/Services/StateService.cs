using manage_grp.Server.Dominian.Interfaces;
using manage_grp.Server.Models;

namespace manage_grp.Server.Dominian.Services
{
    public class StateService
    {
        private readonly IStateRepository _stateRepository;

        public StateService(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        public IEnumerable<State> GetAll()
        {
            return _stateRepository.GetAll();
        }

        public State GetById(int id)
        {
            try
            {
                return _stateRepository.GetById(id);
            }
            catch
            {
                throw;
            }

        }

        public State Save(State state)
        {
            try
            {
                return _stateRepository.Save(state);
            }
            catch
            {
                throw;
            }
        }

        public State Update(int id, State state)
        {
            try
            {
                var existingState = _stateRepository.GetById(id);

                if (existingState == null)
                {
                    throw new Exception("Estado no encontrado");
                }

                state.UpdatedAt = DateTime.Now;
                _stateRepository.Update(id, state);

                return state;
            }
            catch
            {
                throw;
            }
        }

        public State Delete(int id)
        {
            try
            {
                var state = _stateRepository.GetById(id);
                if (state == null)
                {
                    throw new Exception("Estado no encontrado");
                }
                _stateRepository.Delete(state);
                return state;
            }
            catch
            {
                throw;
            }
        }

    }
}
