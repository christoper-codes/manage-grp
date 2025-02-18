using manage_grp.Server.DTOs;
using manage_grp.Server.Models;

namespace manage_grp.Server.Repositories.Interfaces
{
    public interface ITenderPriceTypeRepository
    {
        Task<IEnumerable<TenderPriceType>> GetByDependencyAsync(int dependencyId);

        Task<TenderPriceType?> GetByIdAsync(int id);

        Task<TenderPriceType?> CreateAsync(TenderPriceType priceType, TenderPriceTypeDto priceTypeDto);

        Task<bool?> UpdateAsync(TenderPriceType priceType, TenderPriceTypeDto priceTypeDto);

        Task<bool> DeleteAsync(TenderPriceType priceType);
    }
}