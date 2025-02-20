using manage_grp.Server.DTOs;
using manage_grp.Server.Domain.Interfaces;

namespace manage_grp.Server.Domain.Services
{
    public class FileService
    {
        private readonly IFileRepository _fileUploadRepository;

        public FileService(IFileRepository fileUploadRepository)
        {
            _fileUploadRepository = fileUploadRepository;
        }

        public async Task<List<FileDto>?> SaveFilesAsync(string path, List<IFormFile> FilesDto)
        {
            try
            {
                return await _fileUploadRepository.SaveFilesAsync(path, FilesDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}