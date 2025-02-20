
using manage_grp.Server.DTOs;

namespace manage_grp.Server.Domain.Interfaces
{
    public interface IFileRepository
    {
        Task<List<FileDto>> SaveFilesAsync(string path, List<IFormFile> FilesDto);
    }
}