using manage_grp.Server.Data.Contexts;
using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using manage_grp.Server.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace manage_grp.Server.Repositories
{
    public class ServiceTypeRepository : IServiceTypeRepository
    {
        private readonly AppDbContext _context;

        public ServiceTypeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ServiceType>> GetByAreaIdAsync(int areaId)
        {
            return await _context.ServiceTypes.Where(m => m.AreaId == areaId).ToListAsync();
        }

        public async Task<ServiceType?> GetByIdAsync(int id)
        {
            return await _context.ServiceTypes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ServiceType?> CreateAsync(ServiceType serviceType, ServiceTypeDto serviceTypeDto)
        {
            EntityHelper.UpdateEntityFromDto(Enums.UpdateEntityFromDtoAction.Create, serviceType, serviceTypeDto);

            _context.ServiceTypes.Add(serviceType);

            await _context.SaveChangesAsync();

            return serviceType;
        }

        public async Task<bool?> UpdateAsync(ServiceType serviceType, ServiceTypeDto serviceTypeDto)
        {
            EntityHelper.UpdateEntityFromDto(Enums.UpdateEntityFromDtoAction.Update, serviceType, serviceTypeDto);

            _context.ServiceTypes.Update(serviceType);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(ServiceType serviceType)
        {
            _context.ServiceTypes.Remove(serviceType);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}