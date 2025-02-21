using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using manage_grp.Server.Domain.Interfaces;

namespace manage_grp.Server.Domain.Services
{
    public class DependencyService
    {
        private readonly IDependencyRepository _dependencyRepository;

        public DependencyService(IDependencyRepository dependencyRepository)
        {
            _dependencyRepository = dependencyRepository;
        }

        public async Task<IEnumerable<Dependency>> GetByMunicipalityIdAsync(int municipalityId)
        {
            try
            {
                return await _dependencyRepository.GetByMunicipalityIdAsync(municipalityId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Dependency?> GetByIdAsync(int id)
        {
            try
            {
                return await _dependencyRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Dependency?> CreateAsync(DependencyDto dependencyDto)
        {            
            try
            {
                return await _dependencyRepository.CreateAsync(new Dependency(), dependencyDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        public async Task<bool?> UpdateAsync(int id, DependencyDto dependencyDto)
        {            
            try
            {
                var dependency = await GetByIdAsync(id);

                if (dependency == null)
                {
                    throw new KeyNotFoundException();
                }

                await _dependencyRepository.UpdateAsync(dependency, dependencyDto);

                return true;
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
                var dependency = await _dependencyRepository.GetByIdAsync(id);

                if (dependency == null)
                {
                    throw new KeyNotFoundException();
                }

                return await _dependencyRepository.DeleteAsync(dependency);
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }
    }
}