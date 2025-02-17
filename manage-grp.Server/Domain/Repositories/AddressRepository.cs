

using FluentValidation;
using manage_grp.Server.Data.Contexts;
using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using manage_grp.Server.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace manage_grp.Server.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AppDbContext _context;

        public AddressRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Address>> GetByDependencyAsync(int dependencyId)
        {
            return await _context.Addresses.Where(m => m.DependencyId == dependencyId).ToListAsync();
        }

        public async Task<Address?> GetByIdAsync(int id)
        {
            return await _context.Addresses.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Address?> CreateAsync(Address address, AddressDto addressDto)
        {
            EntityHelper.UpdateEntityFromDto(Enums.UpdateEntityFromDtoAction.Create, address, addressDto);

            _context.Addresses.Add(address);

            await _context.SaveChangesAsync();

            return address;
        }

        public async Task<bool?> UpdateAsync(Address address, AddressDto addressDto)
        {
            EntityHelper.UpdateEntityFromDto(Enums.UpdateEntityFromDtoAction.Update, address, addressDto);

            _context.Addresses.Update(address);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(Address address)
        {
            _context.Addresses.Remove(address);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}