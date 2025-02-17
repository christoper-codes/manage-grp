using manage_grp.Server.DTOs;
using manage_grp.Server.Repositories.Interfaces;
using System;

namespace manage_grp.Server.Repositories
{
    public class FileRepository : IFileRepository
    {
        public FileRepository()
        {
        }

        public async Task<List<FileDto>> SaveFilesAsync(string path, List<IFormFile> FilesDto)
        {
            var savedFiles = new List<FileDto>();

            string uniquePath = Path.Combine("Uploads", path);

            if (!Directory.Exists(uniquePath))
            {
                Directory.CreateDirectory(uniquePath);
            }

            foreach (var file in FilesDto)
            {
                var uniqueFileName = $"{Guid.NewGuid()}_{file.FileName}";
                var filePath = Path.Combine(uniquePath, uniqueFileName);
                
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                savedFiles.Add(new FileDto
                {
                    OriginalFileName = file.FileName,
                    FileName = uniqueFileName,
                    FilePath = filePath,
                    FileSize = file.Length,
                    ContentType = file.ContentType,
                    CreatedAt = DateTime.UtcNow
                });
            }

            return savedFiles;
        }
    }
}