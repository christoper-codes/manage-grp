using manage_grp.Server.DTOs;
using manage_grp.Server.Models;

namespace manage_grp.Server.Domain.Interfaces
{
    public interface ITenderDocumentTypeTenderRepository
    {
        Task<TenderDocumentTypeTender?> GetByIdAsync(int id);

        Task<TenderDocumentTypeTender?> GetByKeysAsync(int tenderId, int tenderDocumentTypeId);

        Task<List<TenderDocumentTypeTender>> CreateListAsync(int tenderId, List<TenderDocumentTypeTenderDto> tenderDocumentTypeTenderDtos);

        Task<TenderDocumentTypeTender?> CreateAsync(TenderDocumentTypeTender tenderDocumentTypeTender, TenderDocumentTypeTenderDto tenderDocumentTypeTenderDto);

        Task<bool> DeleteAsync(TenderDocumentTypeTender tenderDocumentTypeTender);
    }
}