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
    public class TenderTypeController : ControllerBase
    {
        private readonly TenderTypeService _tenderTypeService;
        private readonly IValidator<TenderTypeDto> _validator;

        public TenderTypeController(TenderTypeService tenderTypeService, IValidator<TenderTypeDto> validator)
        {
            _tenderTypeService = tenderTypeService;
            _validator = validator;
        }

        // GET: api/TenderTypes/Dependency/1
        [HttpGet("Dependency/{dependencyId}")]
        public async Task<IActionResult> GetByDependencyAsync(int dependencyId)
        {
            try
            {
                return ApiResponse.SendSuccess("Tipos de licitación recuperados con éxito", await _tenderTypeService.GetByDependencyAsync(dependencyId));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en GetByDependencyAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // GET: api/TenderTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                return ApiResponse.SendSuccess("Tipo de licitación recuperado con éxito", await _tenderTypeService.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en GetByIdAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // POST: api/TenderTypes
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] TenderTypeDto tenderTypeDto)
        {
            try
            {
                ValidationResult validationResult = await _validator.ValidateAsync(tenderTypeDto);

                if (!validationResult.IsValid)
                {
                    return ApiResponse.SendError("Error en los datos enviados", validationResult.Errors, 400);
                }

                return ApiResponse.SendSuccess("Tipo de licitación registrado con éxito", await _tenderTypeService.CreateAsync(tenderTypeDto));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en CreateAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // PUT: api/TenderTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] TenderTypeDto tenderTypeDto)
        {
            try
            {
                ValidationResult validationResult = await _validator.ValidateAsync(tenderTypeDto);

                if (id != tenderTypeDto.Id)
                {
                    validationResult.Errors.Add(new ValidationFailure("Id", "El Id del tipo de licitación no coincide con el Id proporcionado en la URL"));

                    return ApiResponse.SendError("Error en los datos enviados", validationResult.Errors, 400);
                }

                if (!validationResult.IsValid)
                {
                    return ApiResponse.SendError("Error en los datos enviados", validationResult.Errors, 400);
                }

                return ApiResponse.SendSuccess("Tipo de licitación actualizado exitosamente", await _tenderTypeService.UpdateAsync(id, tenderTypeDto));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en UpdateAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // DELETE: api/TenderTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await _tenderTypeService.DeleteAsync(id);

                return ApiResponse.SendSuccess("Tipo de licitación eliminado exitosamente", false);
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en DeleteAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }
    }
}