using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using manage_grp.Server.Repositories.Interfaces;

namespace manage_grp.Server.Services
{
    public class ServiceTypeService
    {
        private readonly IServiceTypeRepository _serviceTypeRepository;

        public ServiceTypeService(IServiceTypeRepository serviceTypeRepository)
        {
            _serviceTypeRepository = serviceTypeRepository;
        }

        public async Task<IEnumerable<ServiceType>> GetByAreaIdAsync(int areaId)
        {
            try
            {
                return await _serviceTypeRepository.GetByAreaIdAsync(areaId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<ServiceType?> GetByIdAsync(int id)
        {
            try
            {
                var serviceType = await _serviceTypeRepository.GetByIdAsync(id);

                if (serviceType == null)
                {
                    throw new KeyNotFoundException();
                }

                return serviceType;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ServiceType?> CreateAsync(ServiceTypeDto serviceTypeDto)
        {
            try
            {
                return await _serviceTypeRepository.CreateAsync(new ServiceType(), serviceTypeDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool?> UpdateAsync(int id, ServiceTypeDto serviceTypeDto)
        {
            try
            {
                var serviceType = await GetByIdAsync(id);

                if (serviceType == null)
                {
                    throw new KeyNotFoundException();
                }

                await _serviceTypeRepository.UpdateAsync(serviceType, serviceTypeDto);

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
                var serviceType = await _serviceTypeRepository.GetByIdAsync(id);

                if (serviceType == null)
                {
                    throw new KeyNotFoundException();
                }

                return await _serviceTypeRepository.DeleteAsync(serviceType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}