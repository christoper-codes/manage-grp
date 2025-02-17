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
    public class PositionController : ControllerBase
    {
        private readonly PositionService _positionService;
        private readonly IValidator<PositionDto> _validator;

        public PositionController(PositionService positionService, IValidator<PositionDto> validator)
        {
            _positionService = positionService;
            _validator = validator;
        }

        // GET: api/Positions/Dependency/1
        [HttpGet("Dependency/{dependencyId}")]
        public async Task<IActionResult> GetByDependencyIdAsync(int dependencyId)
        {
            try
            {
                return ApiResponse.SendSuccess("Posiciones recuperadas con éxito", await _positionService.GetByDependencyIdAsync(dependencyId));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en GetPositions: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // GET: api/Positions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                return ApiResponse.SendSuccess("Posicion recuperada con éxito", await _positionService.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en GetPosition: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // POST: api/Positions
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] PositionDto positionDto)
        {
            try
            {
                ValidationResult validationResult = await _validator.ValidateAsync(positionDto);

                if (!validationResult.IsValid)
                {
                    return ApiResponse.SendError("Error en los datos enviandos", validationResult.Errors, 400);
                }

                return ApiResponse.SendSuccess("Posicion registrada con exito", await _positionService.CreateAsync(positionDto));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en CreateAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // PUT: api/Positions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] PositionDto positionDto)
        {
            try
            {
                ValidationResult validationResult = await _validator.ValidateAsync(positionDto);

                if (id != positionDto.Id)
                {
                    validationResult.Errors.Add(new ValidationFailure("Id", "El Id de la posicion no coincide con el Id proporcionado en la URL"));

                    return ApiResponse.SendError("Error en los datos enviandos", validationResult.Errors, 400);
                }

                if (!validationResult.IsValid)
                {
                    return ApiResponse.SendError("Error en los datos enviandos", validationResult.Errors, 400);
                }                

                return ApiResponse.SendSuccess("Posicion actualizada exitosamente", await _positionService.UpdateAsync(id, positionDto));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en UpdateAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // DELETE: api/Positions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await _positionService.DeleteAsync(id);

                return ApiResponse.SendSuccess("Posicion eliminado exitosamente", false);
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en DeletePosition: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }
    }
}