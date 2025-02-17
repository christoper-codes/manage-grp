
using manage_grp.Server.DTOs;
using manage_grp.Server.Models;

namespace manage_grp.Server.Repositories.Interfaces
{
    public interface IDocumentRepository
    {
        Task<IEnumerable<Document>> GetByDocumentRequirementAsync(int documentRequirementId);

        Task<Document?> GetByIdAsync(int id);

        Task<List<Document>> CreateListAsync(List<Document> documents);

        Task<Document?> CreateAsync(Document document, DocumentDto documentDto);

        Task<bool?> UpdateAsync(Document document, DocumentDto documentDto);

        Task<bool> DeleteAsync(Document document);
    }
}