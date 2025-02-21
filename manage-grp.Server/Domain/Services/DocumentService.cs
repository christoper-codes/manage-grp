using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using manage_grp.Server.Domain.Interfaces;

namespace manage_grp.Server.Domain.Services
{
    public class DocumentService
    {
        private readonly IDocumentRepository _documentRepository;
        private readonly IServiceProvider _serviceProvider;

        public DocumentService(IDocumentRepository documentRepository, IServiceProvider serviceProvider)
        {
            _documentRepository = documentRepository;
            _serviceProvider = serviceProvider;
        }

        public async Task<IEnumerable<Document>> GetByDocumentRequirementAsync(int dependencyId)
        {
            try
            {
                return await _documentRepository.GetByDocumentRequirementAsync(dependencyId);
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        public async Task<Document?> GetByIdAsync(int id)
        {
            try
            {
                return await _documentRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Document>?> CreateListAsync(string path, List<FileGroupDto> FileGroupsDto, List<IFormFile> FilesDto)
        {
            try
            {
                var Files = await _serviceProvider.GetRequiredService<FileService>().SaveFilesAsync(path, FilesDto);

                var savedDocuments = new List<Document>();


                foreach (var FileGroupDto in FileGroupsDto)
                {
                    foreach (var FileDetailDto in FileGroupDto.FileDetailsDto)
                    {
                        var file = Files.FirstOrDefault(f => f.OriginalFileName == FileDetailDto.Name);

                        savedDocuments.Add(new Document
                        {
                            DocumentRequirementId = (int)FileGroupDto.DocumentRequirementId!,
                            Name = file.FileName,
                            MimeType = file.ContentType,
                            Size = file.FileSize,
                            Content = null,
                            Description = null,
                            Path = file.FilePath,
                            CreatedAt = file.CreatedAt
                        });
                    }
                }

                await _documentRepository.CreateListAsync(savedDocuments);

                return savedDocuments;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Document?> CreateAsync(DocumentDto documentDto)
        {
            try
            {
                return await _documentRepository.CreateAsync(new Document(), documentDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool?> UpdateAsync(int id, DocumentDto documentDto)
        {
            try
            {
                var document = await GetByIdAsync(id);

                if (document == null)
                {
                    throw new KeyNotFoundException();
                }

                await _documentRepository.UpdateAsync(document, documentDto);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var document = await _documentRepository.GetByIdAsync(id);

                if (document == null)
                {
                    throw new KeyNotFoundException();
                }

                return await _documentRepository.DeleteAsync(document);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
