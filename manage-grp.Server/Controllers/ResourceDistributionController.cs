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
    public class ResourceDistributionController : ControllerBase
    {
        private readonly ResourceDistributionService _resourceDistributionService;
        private readonly IValidator<ResourceDistributionDto> _validator;

        public ResourceDistributionController(ResourceDistributionService resourceDistributionService, IValidator<ResourceDistributionDto> validator)
        {
            _resourceDistributionService = resourceDistributionService;
            _validator = validator;
        }

        // GET: api/ResourceDistributions/Area/1
        [HttpGet("Area/{areaId}")]
        public async Task<IActionResult> GetByAreaAsync(int areaId)
        {
            try
            {
                return ApiResponse.SendSuccess("Distribuciones de recursos recuperadas con éxito", await _resourceDistributionService.GetByAreaAsync(areaId));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en GetByAreaAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // GET: api/ResourceDistributions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                return ApiResponse.SendSuccess("Distribución de recursos recuperada con éxito", await _resourceDistributionService.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en GetByIdAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // POST: api/ResourceDistributions
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] ResourceDistributionDto resourceDistributionDto)
        {
            try
            {
                ValidationResult validationResult = await _validator.ValidateAsync(resourceDistributionDto);

                if (!validationResult.IsValid)
                {
                    return ApiResponse.SendError("Error en los datos enviados", validationResult.Errors, 400);
                }

                return ApiResponse.SendSuccess("Distribución de recursos registrada con éxito", await _resourceDistributionService.CreateAsync(resourceDistributionDto));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en CreateAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // PUT: api/ResourceDistributions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] ResourceDistributionDto resourceDistributionDto)
        {
            try
            {
                ValidationResult validationResult = await _validator.ValidateAsync(resourceDistributionDto);

                if (id != resourceDistributionDto.Id)
                {
                    validationResult.Errors.Add(new ValidationFailure("Id", "El Id de la distribución de recursos no coincide con el Id proporcionado en la URL"));

                    return ApiResponse.SendError("Error en los datos enviados", validationResult.Errors, 400);
                }

                if (!validationResult.IsValid)
                {
                    return ApiResponse.SendError("Error en los datos enviados", validationResult.Errors, 400);
                }

                return ApiResponse.SendSuccess("Distribución de recursos actualizada exitosamente", await _resourceDistributionService.UpdateAsync(id, resourceDistributionDto));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en UpdateAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // DELETE: api/ResourceDistributions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await _resourceDistributionService.DeleteAsync(id);

                return ApiResponse.SendSuccess("Distribución de recursos eliminada exitosamente", false);
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en DeleteAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }
    }
}