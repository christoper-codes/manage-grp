

using manage_grp.Server.DTOs;
using manage_grp.Server.Models;

namespace manage_grp.Server.Repositories.Interfaces
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetByDependencyAsync(int dependencyId);

        Task<Contact?> GetByIdAsync(int id);

        Task<Contact?> GetByEmailAsync(string email);

        Task<Contact?> CreateAsync(Contact contact, ContactDto contactDto);

        Task<bool?> UpdateAsync(Contact contact, ContactDto contactDto);

        Task<bool> DeleteAsync(Contact contact);
    }
}

