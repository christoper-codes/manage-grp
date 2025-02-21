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
    public class AreaServiceTypeController : ControllerBase
    {
        private readonly AreaServiceTypeService _areaServiceTypeService;
        private readonly IValidator<AreaServiceTypeDto> _validator;

        public AreaServiceTypeController(AreaServiceTypeService areaServiceTypeService, IValidator<AreaServiceTypeDto> validator)
        {
            _areaServiceTypeService = areaServiceTypeService;
            _validator = validator;
        }

        // GET: api/AreaServiceTypes/Area/1
        [HttpGet("Area/{areaId}")]
        public async Task<IActionResult> GetByAreaIdAsync(int areaId)
        {
            try
            {
                return ApiResponse.SendSuccess("Tipos de servicios recuperados con éxito", await _areaServiceTypeService.GetByAreaIdAsync(areaId));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en GetByAreaIdAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // GET: api/AreaServiceTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                return ApiResponse.SendSuccess("Tipos de servicio recuperado con éxito", await _areaServiceTypeService.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en GetByIdAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // POST: api/AreaServiceTypes
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] AreaServiceTypeDto areaServiceTypeDto)
        {
            try
            {
                ValidationResult validationResult = await _validator.ValidateAsync(areaServiceTypeDto);

                if (!validationResult.IsValid)
                {
                    return ApiResponse.SendError("Error en los datos enviados", validationResult.Errors, 400);
                }

                return ApiResponse.SendSuccess("Tipos de servicio registrado con éxito", await _areaServiceTypeService.CreateAsync(areaServiceTypeDto));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en CreateAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // PUT: api/AreaServiceTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] AreaServiceTypeDto areaServiceTypeDto)
        {
            try
            {
                ValidationResult validationResult = await _validator.ValidateAsync(areaServiceTypeDto);

                if (id != areaServiceTypeDto.Id)
                {
                    validationResult.Errors.Add(new ValidationFailure("Id", "El Id del tipo de servicio no coincide con el Id proporcionado en la URL"));

                    return ApiResponse.SendError("Error en los datos enviados", validationResult.Errors, 400);
                }

                if (!validationResult.IsValid)
                {
                    return ApiResponse.SendError("Error en los datos enviados", validationResult.Errors, 400);
                }

                return ApiResponse.SendSuccess("Tipos de servicio actualizado exitosamente", await _areaServiceTypeService.UpdateAsync(id, areaServiceTypeDto));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en UpdateAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // DELETE: api/AreaServiceTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await _areaServiceTypeService.DeleteAsync(id);

                return ApiResponse.SendSuccess("Tipos de servicio eliminado exitosamente", false);
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en DeleteAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }
    }
}