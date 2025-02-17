using manage_grp.Server.DTOs;
using manage_grp.Server.Models;
using manage_grp.Server.Repositories.Interfaces;

namespace manage_grp.Server.Services
{
    public class DocumentTypeService
    {
        private readonly IDocumentTypeRepository _documentTypeRepository;

        public DocumentTypeService(IDocumentTypeRepository documentTypeRepository)
        {
            _documentTypeRepository = documentTypeRepository;
        }

        public async Task<IEnumerable<DocumentType>> GetByDependencyIdAsync(int dependencyId)
        {
            try
            {
                return await _documentTypeRepository.GetByDependencyIdAsync(dependencyId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DocumentType?> GetByIdAsync(int id)
        {
            try
            {
                var documentType = await _documentTypeRepository.GetByIdAsync(id);

                if (documentType == null)
                {
                    throw new KeyNotFoundException();
                }

                return documentType;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DocumentType?> CreateAsync(DocumentTypeDto documentTypeDto)
        {
            try
            {
                return await _documentTypeRepository.CreateAsync(new DocumentType(), documentTypeDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool?> UpdateAsync(int id, DocumentTypeDto documentTypeDto)
        {
            try
            {
                var documentType = await GetByIdAsync(id);
           
                if (documentType == null)
                {
                    throw new KeyNotFoundException();
                }

                await _documentTypeRepository.UpdateAsync(documentType, documentTypeDto);

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
                var documentType = await _documentTypeRepository.GetByIdAsync(id);

                if (documentType == null)
                {
                    throw new KeyNotFoundException();
                }

                return await _documentTypeRepository.DeleteAsync(documentType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
