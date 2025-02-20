

using manage_grp.Server.DTOs;
using manage_grp.Server.Models;

namespace manage_grp.Server.Domain.Interfaces
{
    public interface ITenderRepository
    {
        Task<Tender?> GetByIdAsync(int id);

        Task<Tender?> CreateAsync(Tender tender, TenderDto tenderDto);

        Task<bool?> UpdateAsync(Tender tender, TenderDto tenderDto);

        Task<bool> DeleAsync(Tender tender);
    }
}