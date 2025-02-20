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
    public class DependencyController : ControllerBase
    {
        private readonly DependencyService _dependencyService;
        private readonly IValidator<DependencyDto> _validator;

        public DependencyController(DependencyService dependencyService, IValidator<DependencyDto> validator)
        {
            _dependencyService = dependencyService;
            _validator = validator;
        }

        // GET: api/Dependencies/Municipality/1
        [HttpGet("Municipality/{municipalityId}")]
        public async Task<IActionResult> GetByMunicipalityIdAsync(int municipalityId)
        {
            try
            {
                return ApiResponse.SendSuccess("Dependencias recuperadas con éxito", await _dependencyService.GetByMunicipalityIdAsync(municipalityId));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en GetByMunicipalityIdAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // GET: api/Dependencies/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                return ApiResponse.SendSuccess("Dependencia recuperada con éxito", await _dependencyService.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en GetDependency: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // POST: api/Dependencies
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] DependencyDto dependencyDto)
        {
            try
            {
                ValidationResult validationResult = await _validator.ValidateAsync(dependencyDto);

                if (!validationResult.IsValid)
                {
                    return ApiResponse.SendError("Error en los datos enviandos", validationResult.Errors, 400);
                }

                return ApiResponse.SendSuccess("Dependencia registrada con exitoso", await _dependencyService.CreateAsync(dependencyDto));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en CreateAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // PUT: api/Dependencies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] DependencyDto dependencyDto)
        {
            try
            {
                ValidationResult validationResult = await _validator.ValidateAsync(dependencyDto);

                if (id != dependencyDto.Id)
                {
                    validationResult.Errors.Add(new ValidationFailure("Id", "El Id de la dependencia no coincide con el Id proporcionado en la URL"));

                    return ApiResponse.SendError("Error en los datos enviandos", validationResult.Errors, 400);
                }

                if (!validationResult.IsValid)
                {
                    return ApiResponse.SendError("Error en los datos enviandos", validationResult.Errors, 400);
                }                

                return ApiResponse.SendSuccess("Dependencia actualizada exitosamente", await _dependencyService.UpdateAsync(id, dependencyDto));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en UpdateAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // DELETE: api/Dependencies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await _dependencyService.DeleteAsync(id);

                return ApiResponse.SendSuccess("Dependencia eliminado exitosamente", false);
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en DeleteDependency: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }
    }
}