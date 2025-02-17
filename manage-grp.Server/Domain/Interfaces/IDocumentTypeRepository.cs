
using manage_grp.Server.DTOs;
using manage_grp.Server.Models;

namespace manage_grp.Server.Repositories.Interfaces
{
    public interface IDocumentTypeRepository
    {
        Task<IEnumerable<DocumentType>> GetByDependencyIdAsync(int dependencyId);

        Task<DocumentType?> GetByIdAsync(int id);

        Task<DocumentType?> CreateAsync(DocumentType address, DocumentTypeDto documentTypeDto);

        Task<bool?> UpdateAsync(DocumentType address, DocumentTypeDto documentTypeDto);

        Task<bool> DeleteAsync(DocumentType documentType);
    }
}