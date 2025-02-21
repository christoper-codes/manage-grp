using FluentValidation;
using FluentValidation.Results;
using manage_grp.Server.DTOs;
using manage_grp.Server.Helpers;
using manage_grp.Server.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace repro_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceTypeController : ControllerBase
    {
        private readonly ResourceTypeService _resourceTypeService;
        private readonly IValidator<ResourceTypeDto> _validator;

        public ResourceTypeController(ResourceTypeService resourceTypeService, IValidator<ResourceTypeDto> validator)
        {
            _resourceTypeService = resourceTypeService;
            _validator = validator;
        }

        // GET: api/ResourceTypes/Dependency/1
        [HttpGet("Dependency/{dependencyId}")]
        public async Task<IActionResult> GetByDependencyIdAsync(int dependencyId)
        {
            try
            {
                return ApiResponse.SendSuccess("Tipos de recursos recuperados con éxito", await _resourceTypeService.GetByDependencyIdAsync(dependencyId));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en GetByDependencyIdAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // GET: api/ResourceTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                return ApiResponse.SendSuccess("Tipo de recurso recuperado con éxito", await _resourceTypeService.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en GetByIdAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // POST: api/ResourceTypes
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ResourceTypeDto resourceTypeDto)
        {
            try
            {
                ValidationResult validationResult = await _validator.ValidateAsync(resourceTypeDto);

                if (!validationResult.IsValid)
                {
                    return ApiResponse.SendError("Error en los datos enviados", validationResult.Errors, 400);
                }

                return ApiResponse.SendSuccess("Tipo de recurso registrado con éxito", await _resourceTypeService.CreateAsync(resourceTypeDto));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en PostResourceType: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // PUT: api/ResourceTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] ResourceTypeDto resourceTypeDto)
        {
            try
            {
                ValidationResult validationResult = await _validator.ValidateAsync(resourceTypeDto);

                if (id != resourceTypeDto.Id)
                {
                    validationResult.Errors.Add(new ValidationFailure("Id", "El Id del tipo de recurso no coincide con el Id proporcionado en la URL"));

                    return ApiResponse.SendError("Error en los datos enviados", validationResult.Errors, 400);
                }

                if (!validationResult.IsValid)
                {
                    return ApiResponse.SendError("Error en los datos enviados", validationResult.Errors, 400);
                }

                return ApiResponse.SendSuccess("Tipo de recurso actualizado exitosamente", await _resourceTypeService.UpdateAsync(id, resourceTypeDto));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en UpdateAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // DELETE: api/ResourceTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await _resourceTypeService.DeleteAsync(id);

                return ApiResponse.SendSuccess("Tipo de recurso eliminado exitosamente", false);
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en DeleteAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }
    }
}