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
    public class ServiceTypeController : ControllerBase
    {
        private readonly ServiceTypeService _serviceTypeService;
        private readonly IValidator<ServiceTypeDto> _validator;

        public ServiceTypeController(ServiceTypeService serviceTypeService, IValidator<ServiceTypeDto> validator)
        {
            _serviceTypeService = serviceTypeService;
            _validator = validator;
        }

        // GET: api/ServiceTypes/Area/1
        [HttpGet("Area/{areaId}")]
        public async Task<IActionResult> GetByAreaIdAsync(int areaId)
        {
            try
            {
                return ApiResponse.SendSuccess("Tipos de servicios recuperados con éxito", await _serviceTypeService.GetByAreaIdAsync(areaId));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en GetByAreaIdAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // GET: api/ServiceTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                return ApiResponse.SendSuccess("Tipos de servicio recuperado con éxito", await _serviceTypeService.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en GetByIdAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // POST: api/ServiceTypes
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ServiceTypeDto serviceTypeDto)
        {
            try
            {
                ValidationResult validationResult = await _validator.ValidateAsync(serviceTypeDto);

                if (!validationResult.IsValid)
                {
                    return ApiResponse.SendError("Error en los datos enviados", validationResult.Errors, 400);
                }

                return ApiResponse.SendSuccess("Tipos de servicio registrado con éxito", await _serviceTypeService.CreateAsync(serviceTypeDto));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en CreateAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // PUT: api/ServiceTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] ServiceTypeDto serviceTypeDto)
        {
            try
            {
                ValidationResult validationResult = await _validator.ValidateAsync(serviceTypeDto);

                if (id != serviceTypeDto.Id)
                {
                    validationResult.Errors.Add(new ValidationFailure("Id", "El Id del tipo de servicio no coincide con el Id proporcionado en la URL"));

                    return ApiResponse.SendError("Error en los datos enviados", validationResult.Errors, 400);
                }

                if (!validationResult.IsValid)
                {
                    return ApiResponse.SendError("Error en los datos enviados", validationResult.Errors, 400);
                }

                return ApiResponse.SendSuccess("Tipos de servicio actualizado exitosamente", await _serviceTypeService.UpdateAsync(id, serviceTypeDto));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en UpdateAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // DELETE: api/ServiceTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await _serviceTypeService.DeleteAsync(id);

                return ApiResponse.SendSuccess("Tipos de servicio eliminado exitosamente", false);
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en DeleteAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }
    }
}