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
    public class ResourceDistributionDocumentTypeController : ControllerBase
    {
        private readonly ResourceDistributionDocumentTypeService _tenderDocumentTypeService;
        private readonly IValidator<ResourceDistributionDocumentTypeDto> _validator;

        public ResourceDistributionDocumentTypeController(ResourceDistributionDocumentTypeService tenderDocumentTypeService, IValidator<ResourceDistributionDocumentTypeDto> validator)
        {
            _tenderDocumentTypeService = tenderDocumentTypeService;
            _validator = validator;
        }

        // GET: api/ResourceDistributionDocumentTypes/Dependency/1
        [HttpGet("Dependency/{dependencyId}")]
        public async Task<IActionResult> GetByDependencyIdAsync(int dependencyId)
        {
            try
            {
                return ApiResponse.SendSuccess("Tipos de documentos recuperados con éxito", await _tenderDocumentTypeService.GetByDependencyIdAsync(dependencyId));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en GetByDependencyIdAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // GET: api/ResourceDistributionDocumentTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                return ApiResponse.SendSuccess("Tipos de documento recuperado con éxito", await _tenderDocumentTypeService.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en GetByIdAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // POST: api/ResourceDistributionDocumentTypes
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ResourceDistributionDocumentTypeDto tenderDocumentTypeDto)
        {
            try
            {
                ValidationResult validationResult = await _validator.ValidateAsync(tenderDocumentTypeDto);

                if (!validationResult.IsValid)
                {
                    return ApiResponse.SendError("Error en los datos enviandos", validationResult.Errors, 400);
                }

                return ApiResponse.SendSuccess("Tipo de documento registrada con exito", await _tenderDocumentTypeService.CreateAsync(tenderDocumentTypeDto));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en CreateAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // PUT: api/ResourceDistributionDocumentTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] ResourceDistributionDocumentTypeDto tenderDocumentTypeDto)
        {
            try
            {
                ValidationResult validationResult = await _validator.ValidateAsync(tenderDocumentTypeDto);

                if (id != tenderDocumentTypeDto.Id)
                {
                    validationResult.Errors.Add(new ValidationFailure("Id", "El Id del tipo de documento no coincide con el Id proporcionado en la URL"));

                    return ApiResponse.SendError("Error en los datos enviandos", validationResult.Errors, 400);
                }

                if (!validationResult.IsValid)
                {
                    return ApiResponse.SendError("Error en los datos enviandos", validationResult.Errors, 400);
                }

                return ApiResponse.SendSuccess("Tipo de documento actualizado exitosamente", await _tenderDocumentTypeService.UpdateAsync(id, tenderDocumentTypeDto));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en UpdateAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // DELETE: api/ResourceDistributionDocumentTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await _tenderDocumentTypeService.DeleteAsync(id);

                return ApiResponse.SendSuccess("Direccion eliminado exitosamente", false);
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en DeleteAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }
    }
}