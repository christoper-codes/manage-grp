using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using manage_grp.Server.Domain.Interfaces;

namespace manage_grp.Server.Domain.Services
{
    public class AddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<IEnumerable<Address>> GetByDependencyAsync(int dependencyId)
        {
            try
            {
                return await _addressRepository.GetByDependencyAsync(dependencyId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<Address?> GetByIdAsync(int id)
        {
            try
            {
                return await _addressRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Address?> CreateAsync(AddressDto addressDto)
        {
            try
            {
                return await _addressRepository.CreateAsync(new Address(), addressDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        public async Task<bool?> UpdateAsync(int id, AddressDto addressDto)
        {
            try
            {
                var address = await GetByIdAsync(id);

                if (address == null)
                {
                    throw new KeyNotFoundException();
                }

                await _addressRepository.UpdateAsync(address, addressDto);

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
                var address = await _addressRepository.GetByIdAsync(id);

                if (address == null)
                {
                    throw new KeyNotFoundException();
                }

                return await _addressRepository.DeleteAsync(address);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
