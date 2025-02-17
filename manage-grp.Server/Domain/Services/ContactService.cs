using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using manage_grp.Server.Repositories.Interfaces;

namespace manage_grp.Server.Services
{
    public class ContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<IEnumerable<Contact>> GetByDependencyAsync(int dependencyId)
        {
            try
            {
                return await _contactRepository.GetByDependencyAsync(dependencyId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Contact?> GetByEmailAsync(string email)
        {
            try
            {
                var contact = await _contactRepository.GetByEmailAsync(email);

                if (contact == null)
                {
                    throw new KeyNotFoundException();
                }

                return contact;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Contact?> GetByIdAsync(int id)
        {
            try
            {
                var contact = await _contactRepository.GetByIdAsync(id);

                if (contact == null)
                {
                    throw new KeyNotFoundException();
                }

                return contact;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Contact?> CreateAsync(ContactDto contactDto)
        {
            try
            {
                return await _contactRepository.CreateAsync(new Contact(), contactDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool?> UpdateAsync(int id, ContactDto contactDto)
        {
            try
            {
                var contact = await GetByIdAsync(id);

                if (contact == null)
                {
                    throw new KeyNotFoundException();
                }

                await _contactRepository.UpdateAsync(contact, contactDto);

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
                var contact = await _contactRepository.GetByIdAsync(id);

                if (contact == null)
                {
                    throw new KeyNotFoundException();
                }

                return await _contactRepository.DeleteAsync(contact);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
