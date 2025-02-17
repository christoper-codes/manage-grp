using FluentValidation;
using FluentValidation.Results;
using manage_grp.Server.DTOs;
using manage_grp.Server.Helpers;
using manage_grp.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace repro_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentTypeController : ControllerBase
    {
        private readonly DocumentTypeService _documentTypeService;
        private readonly IValidator<DocumentTypeDto> _validator;

        public DocumentTypeController(DocumentTypeService documentTypeService, IValidator<DocumentTypeDto> validator)
        {
            _documentTypeService = documentTypeService;
            _validator = validator;
        }

        // GET: api/DocumentTypes/Dependency/1
        [HttpGet("Dependency/{dependencyId}")]
        public async Task<IActionResult> GetDocumentTypes(int dependencyId)
        {
            try
            {
                return ApiResponse.SendSuccess("Tipos de documentos recuperados con éxito", await _documentTypeService.GetByDependencyIdAsync(dependencyId));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en GetDocumentTypes: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // GET: api/DocumentTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDocumentType(int id)
        {
            try
            {
                return ApiResponse.SendSuccess("Tipos de documento recuperado con éxito", await _documentTypeService.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en GetDocumentType: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // POST: api/DocumentTypes
        [HttpPost]
        public async Task<IActionResult> PostDocumentType([FromBody] DocumentTypeDto documentTypeDto)
        {
            try
            {
                ValidationResult validationResult = await _validator.ValidateAsync(documentTypeDto);

                if (!validationResult.IsValid)
                {
                    return ApiResponse.SendError("Error en los datos enviandos", validationResult.Errors, 400);
                }

                return ApiResponse.SendSuccess("Tipo de documento registrada con exito", await _documentTypeService.CreateAsync(documentTypeDto));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en PostDocumentType: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // PUT: api/DocumentTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocumentType(int id, [FromBody] DocumentTypeDto documentTypeDto)
        {
            try
            {
                ValidationResult validationResult = await _validator.ValidateAsync(documentTypeDto);

                if (id != documentTypeDto.Id)
                {
                    validationResult.Errors.Add(new ValidationFailure("Id", "El Id del tipo de documento no coincide con el Id proporcionado en la URL"));

                    return ApiResponse.SendError("Error en los datos enviandos", validationResult.Errors, 400);
                }

                if (!validationResult.IsValid)
                {
                    return ApiResponse.SendError("Error en los datos enviandos", validationResult.Errors, 400);
                }                

                return ApiResponse.SendSuccess("Tipo de documento actualizado exitosamente", await _documentTypeService.UpdateAsync(id, documentTypeDto));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en PutDocumentType: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // DELETE: api/DocumentTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocumentType(int id)
        {
            try
            {
                await _documentTypeService.DeleteAsync(id);

                return ApiResponse.SendSuccess("Direccion eliminado exitosamente", false);
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en DeleteDocumentType: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }
    }
}