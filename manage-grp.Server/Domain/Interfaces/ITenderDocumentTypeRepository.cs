
using manage_grp.Server.DTOs;
using manage_grp.Server.Models;

namespace manage_grp.Server.Domain.Interfaces
{
    public interface ITenderDocumentTypeRepository
    {
        Task<IEnumerable<TenderDocumentType>> GetByDependencyIdAsync(int dependencyId);

        Task<TenderDocumentType?> GetByIdAsync(int id);

        Task<TenderDocumentType?> CreateAsync(TenderDocumentType tenderDocumentType, TenderDocumentTypeDto tenderDocumentTypeDto);

        Task<bool?> UpdateAsync(TenderDocumentType tenderDocumentType, TenderDocumentTypeDto tenderDocumentTypeDto);

        Task<bool> DeleteAsync(TenderDocumentType tenderDocumentType);
    }
}