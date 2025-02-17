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
    public class AreaController : ControllerBase
    {
        private readonly AreaService _areaService;
        private readonly IValidator<AreaDto> _validator;

        public AreaController(AreaService areaService, IValidator<AreaDto> validator)
        {
            _areaService = areaService;
            _validator = validator;
        }

        // GET: api/Areas/Dependency/1
        [HttpGet("Dependency/{dependencyId}")]
        public async Task<IActionResult> GetByDependencyAsync(int dependencyId)
        {
            try
            {
                return ApiResponse.SendSuccess("Áreas recuperadas con éxito", await _areaService.GetByDependencyAsync(dependencyId));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en GetByDependencyAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // GET: api/Areas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                return ApiResponse.SendSuccess("Área recuperada con éxito", await _areaService.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en GetByIdAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // POST: api/Areas
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] AreaDto areaDto)
        {
            try
            {
                ValidationResult validationResult = await _validator.ValidateAsync(areaDto);

                if (!validationResult.IsValid)
                {
                    return ApiResponse.SendError("Error en los datos enviados", validationResult.Errors, 400);
                }

                return ApiResponse.SendSuccess("Área registrada con éxito", await _areaService.CreateAsync(areaDto));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en PostArea: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // PUT: api/Areas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] AreaDto areaDto)
        {
            try
            {
                ValidationResult validationResult = await _validator.ValidateAsync(areaDto);

                if (id != areaDto.Id)
                {
                    validationResult.Errors.Add(new ValidationFailure("Id", "El Id del área no coincide con el Id proporcionado en la URL"));

                    return ApiResponse.SendError("Error en los datos enviados", validationResult.Errors, 400);
                }

                if (!validationResult.IsValid)
                {
                    return ApiResponse.SendError("Error en los datos enviados", validationResult.Errors, 400);
                }

                return ApiResponse.SendSuccess("Área actualizada exitosamente", await _areaService.UpdateAsync(id, areaDto));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en UpdateAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // DELETE: api/Areas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await _areaService.DeleteAsync(id);

                return ApiResponse.SendSuccess("Área eliminada exitosamente", false);
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en DeleteAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }
    }
}