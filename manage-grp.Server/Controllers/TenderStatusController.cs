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
    public class TenderStatusController : ControllerBase
    {
        private readonly TenderStatusService _tenderStatusService;
        private readonly IValidator<TenderStatusDto> _validator;

        public TenderStatusController(TenderStatusService tenderStatusService, IValidator<TenderStatusDto> validator)
        {
            _tenderStatusService = tenderStatusService;
            _validator = validator;
        }

        // GET: api/TenderStatuses/Dependency/1
        [HttpGet("Dependency/{dependencyId}")]
        public async Task<IActionResult> GetByDependencyAsync(int dependencyId)
        {
            try
            {
                return ApiResponse.SendSuccess("Estados de licitación recuperados con éxito", await _tenderStatusService.GetByDependencyAsync(dependencyId));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en GetByDependencyAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // GET: api/TenderStatuses/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                return ApiResponse.SendSuccess("Estado de licitación recuperado con éxito", await _tenderStatusService.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en GetByIdAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // POST: api/TenderStatuses
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] TenderStatusDto tenderStatusDto)
        {
            try
            {
                ValidationResult validationResult = await _validator.ValidateAsync(tenderStatusDto);

                if (!validationResult.IsValid)
                {
                    return ApiResponse.SendError("Error en los datos enviados", validationResult.Errors, 400);
                }

                return ApiResponse.SendSuccess("Estado de licitación registrado con éxito", await _tenderStatusService.CreateAsync(tenderStatusDto));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en CreateAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // PUT: api/TenderStatuses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] TenderStatusDto tenderStatusDto)
        {
            try
            {
                ValidationResult validationResult = await _validator.ValidateAsync(tenderStatusDto);

                if (id != tenderStatusDto.Id)
                {
                    validationResult.Errors.Add(new ValidationFailure("Id", "El Id del estado de licitación no coincide con el Id proporcionado en la URL"));

                    return ApiResponse.SendError("Error en los datos enviados", validationResult.Errors, 400);
                }

                if (!validationResult.IsValid)
                {
                    return ApiResponse.SendError("Error en los datos enviados", validationResult.Errors, 400);
                }

                return ApiResponse.SendSuccess("Estado de licitación actualizado exitosamente", await _tenderStatusService.UpdateAsync(id, tenderStatusDto));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en UpdateAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // DELETE: api/TenderStatuses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await _tenderStatusService.DeleteAsync(id);

                return ApiResponse.SendSuccess("Estado de licitación eliminado exitosamente", false);
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en DeleteAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }
    }
}