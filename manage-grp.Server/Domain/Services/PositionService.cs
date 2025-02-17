using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using manage_grp.Server.Repositories.Interfaces;

namespace manage_grp.Server.Services
{
    public class PositionService
    {
        private readonly IPositionRepository _positionRepository;

        public PositionService(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }

        public async Task<IEnumerable<Position>> GetByDependencyIdAsync(int dependencyId)
        {
            try
            {
                return await _positionRepository.GetByDependencyIdAsync(dependencyId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Position?> GetByIdAsync(int id)
        {
            try
            {
                var position = await _positionRepository.GetByIdAsync(id);

                if (position == null)
                {
                    throw new KeyNotFoundException();
                }

                return position;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Position?> CreateAsync(PositionDto positionDto)
        {
            try
            {
                return await _positionRepository.CreateAsync(new Position(), positionDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool?> UpdateAsync(int id, PositionDto positionDto)
        {
            try
            {
                var position = await GetByIdAsync(id);
           
                if (position == null)
                {
                    throw new KeyNotFoundException();
                }

                return await _positionRepository.UpdateAsync(position, positionDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var position = await _positionRepository.GetByIdAsync(id);

                if (position == null)
                {
                    throw new KeyNotFoundException();
                }

                return await _positionRepository.DeleteAsync(position);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
