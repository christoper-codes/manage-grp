

using FluentValidation;
using manage_grp.Server.Data.Contexts;
using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using manage_grp.Server.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace manage_grp.Server.Domain.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext _context;

        public ContactRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Contact>> GetByDependencyAsync(int dependencyId)
        {
            return await _context.Contacts.Where(m => m.DependencyId == dependencyId).ToListAsync();
        }

        public async Task<Contact?> GetByEmailAsync(string email)
        {
            return await _context.Contacts.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<Contact?> GetByIdAsync(int id)
        {
            return await _context.Contacts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Contact?> CreateAsync(Contact contact, ContactDto contactDto)
        {
            EntityHelper.UpdateEntityFromDto(Enums.UpdateEntityFromDtoAction.Create, contact, contactDto);

            _context.Contacts.Add(contact);

            await _context.SaveChangesAsync();

            return contact;
        }

        public async Task<bool?> UpdateAsync(Contact contact, ContactDto contactDto)
        {            
            EntityHelper.UpdateEntityFromDto(Enums.UpdateEntityFromDtoAction.Update, contact, contactDto);

            _context.Contacts.Update(contact);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(Contact contact)
        {
            _context.Contacts.Remove(contact);

            await _context.SaveChangesAsync();

            return true;
        }        
    }
}