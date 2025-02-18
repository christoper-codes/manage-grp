using manage_grp.Server.DTOs;
using manage_grp.Server.Models;

namespace manage_grp.Server.Repositories.Interfaces
{
    public interface IPriceTypeRepository
    {
        Task<IEnumerable<PriceType>> GetByDependencyAsync(int dependencyId);

        Task<PriceType?> GetByIdAsync(int id);

        Task<PriceType?> CreateAsync(PriceType priceType, PriceTypeDto priceTypeDto);

        Task<bool?> UpdateAsync(PriceType priceType, PriceTypeDto priceTypeDto);

        Task<bool> DeleteAsync(PriceType priceType);
    }
}