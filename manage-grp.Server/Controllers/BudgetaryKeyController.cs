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
    public class BudgetaryKeyController : ControllerBase
    {
        private readonly BudgetaryKeyService _budgetaryKeyService;
        private readonly IValidator<BudgetaryKeyDto> _validator;

        public BudgetaryKeyController(BudgetaryKeyService budgetaryKeyService, IValidator<BudgetaryKeyDto> validator)
        {
            _budgetaryKeyService = budgetaryKeyService;
            _validator = validator;
        }

        // GET: api/BudgetaryKeys/Dependency/1
        [HttpGet("Dependency/{dependencyId}")]
        public async Task<IActionResult> GetByDependencyAsync(int dependencyId)
        {
            try
            {
                return ApiResponse.SendSuccess("Clave Presupuestales recuperadas con éxito", await _budgetaryKeyService.GetByDependencyAsync(dependencyId));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en GetByDependencyAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // GET: api/BudgetaryKeys/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                return ApiResponse.SendSuccess("Clave Presupuestal recuperada con éxito", await _budgetaryKeyService.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en GetByIdAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // POST: api/BudgetaryKeys
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] BudgetaryKeyDto budgetaryKeyDto)
        {
            try
            {
                ValidationResult validationResult = await _validator.ValidateAsync(budgetaryKeyDto);

                if (!validationResult.IsValid)
                {
                    return ApiResponse.SendError("Error en los datos enviandos", validationResult.Errors, 400);
                }

                return ApiResponse.SendSuccess("Clave Presupuestal registrada con exito", await _budgetaryKeyService.CreateAsync(budgetaryKeyDto));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en CreateAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // PUT: api/BudgetaryKeys/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] BudgetaryKeyDto budgetaryKeyDto)
        {
            try
            {
                ValidationResult validationResult = await _validator.ValidateAsync(budgetaryKeyDto);

                if (id != budgetaryKeyDto.Id)
                {
                    validationResult.Errors.Add(new ValidationFailure("Id", "El Id de la clave Presupuestal no coincide con el Id proporcionado en la URL"));

                    return ApiResponse.SendError("Error en los datos enviandos", validationResult.Errors, 400);
                }

                if (!validationResult.IsValid)
                {
                    return ApiResponse.SendError("Error en los datos enviandos", validationResult.Errors, 400);
                }                

                return ApiResponse.SendSuccess("Clave Presupuestal actualizada exitosamente", await _budgetaryKeyService.UpdateAsync(id, budgetaryKeyDto));
            }
            catch (Exception ex)
            {               
                return ApiResponse.SendError($"Excepción generada en UpdateAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // DELETE: api/BudgetaryKeys/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleAsync(int id)
        {
            try
            {
                await _budgetaryKeyService.DeleAsync(id);

                return ApiResponse.SendSuccess("Clave Presupuestal eliminado exitosamente", false);
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en DeleAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }
    }
}