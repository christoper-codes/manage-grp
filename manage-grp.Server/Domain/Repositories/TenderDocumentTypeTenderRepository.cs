using manage_grp.Server.Data.Contexts;
using manage_grp.Server.Domain.Interfaces;
using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace manage_grp.Server.Domain.Repositories
{
    public class TenderDocumentTypeTenderRepository : ITenderDocumentTypeTenderRepository
    {
        private readonly AppDbContext _context;

        public TenderDocumentTypeTenderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TenderDocumentTypeTender?> GetByIdAsync(int id)
        {
            return await _context.TenderDocumentTypeTenders.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TenderDocumentTypeTender?> GetByKeysAsync(int tenderId, int tenderDocumentTypeTenderId)
        {
            return await _context.TenderDocumentTypeTenders.FirstOrDefaultAsync(x => x.TenderId == tenderId && x.TenderDocumentTypeId == tenderDocumentTypeTenderId);
        }

        public async Task<List<TenderDocumentTypeTender>> CreateListAsync(int tenderId, List<TenderDocumentTypeTenderDto> tenderDocumentTypeTenderDtos)
        {
            var tenderDocumentTypeTenders = tenderDocumentTypeTenderDtos.Select(dto => new TenderDocumentTypeTender
            {
                TenderId = tenderId,
                TenderDocumentTypeId = dto.TenderDocumentTypeId
            }).ToList();

            _context.TenderDocumentTypeTenders.AddRange(tenderDocumentTypeTenders);

            await _context.SaveChangesAsync();

            return tenderDocumentTypeTenders;
        }

        public async Task<TenderDocumentTypeTender?> CreateAsync(TenderDocumentTypeTender tenderDocumentTypeTender, TenderDocumentTypeTenderDto tenderDocumentTypeTenderDto)
        {
            EntityHelper.UpdateEntityFromDto(Enums.UpdateEntityFromDtoAction.Create, tenderDocumentTypeTender, tenderDocumentTypeTenderDto);

            _context.TenderDocumentTypeTenders.Add(tenderDocumentTypeTender);

            await _context.SaveChangesAsync();

            return tenderDocumentTypeTender;
        }

        public async Task<bool> DeleteAsync(TenderDocumentTypeTender tenderDocumentTypeTender)
        {
            _context.TenderDocumentTypeTenders.Remove(tenderDocumentTypeTender);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}