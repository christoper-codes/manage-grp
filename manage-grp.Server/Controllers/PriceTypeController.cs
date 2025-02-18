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
    public class PriceTypeController : ControllerBase
    {
        private readonly PriceTypeService _priceTypeService;
        private readonly IValidator<PriceTypeDto> _validator;

        public PriceTypeController(PriceTypeService priceTypeService, IValidator<PriceTypeDto> validator)
        {
            _priceTypeService = priceTypeService;
            _validator = validator;
        }

        // GET: api/PriceTypes/Dependency/1
        [HttpGet("Dependency/{dependencyId}")]
        public async Task<IActionResult> GetByDependencyAsync(int dependencyId)
        {
            try
            {
                return ApiResponse.SendSuccess("Tipos de precio recuperados con éxito", await _priceTypeService.GetByDependencyAsync(dependencyId));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en GetByDependencyAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // GET: api/PriceTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                return ApiResponse.SendSuccess("Tipo de precio recuperado con éxito", await _priceTypeService.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en GetByIdAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // POST: api/PriceTypes
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] PriceTypeDto priceTypeDto)
        {
            try
            {
                ValidationResult validationResult = await _validator.ValidateAsync(priceTypeDto);

                if (!validationResult.IsValid)
                {
                    return ApiResponse.SendError("Error en los datos enviados", validationResult.Errors, 400);
                }

                return ApiResponse.SendSuccess("Tipo de precio registrado con éxito", await _priceTypeService.CreateAsync(priceTypeDto));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en CreateAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // PUT: api/PriceTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] PriceTypeDto priceTypeDto)
        {
            try
            {
                ValidationResult validationResult = await _validator.ValidateAsync(priceTypeDto);

                if (id != priceTypeDto.Id)
                {
                    validationResult.Errors.Add(new ValidationFailure("Id", "El Id del tipo de precio no coincide con el Id proporcionado en la URL"));

                    return ApiResponse.SendError("Error en los datos enviados", validationResult.Errors, 400);
                }

                if (!validationResult.IsValid)
                {
                    return ApiResponse.SendError("Error en los datos enviados", validationResult.Errors, 400);
                }

                return ApiResponse.SendSuccess("Tipo de precio actualizado exitosamente", await _priceTypeService.UpdateAsync(id, priceTypeDto));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en UpdateAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // DELETE: api/PriceTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await _priceTypeService.DeleteAsync(id);

                return ApiResponse.SendSuccess("Tipo de precio eliminado exitosamente", false);
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en DeleteAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }
    }
}