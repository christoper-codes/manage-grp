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
    public class BudgetKeyDefaultController : ControllerBase
    {
        private readonly BudgetKeyDefaultService _budgetKeyDefaultService;
        private readonly IValidator<BudgetKeyDefaultDto> _validator;

        public BudgetKeyDefaultController(BudgetKeyDefaultService budgetKeyDefaultService, IValidator<BudgetKeyDefaultDto> validator)
        {
            _budgetKeyDefaultService = budgetKeyDefaultService;
            _validator = validator;
        }

        // GET: api/BudgetKeyDefaults/Dependency/1
        [HttpGet("Dependency/{dependencyId}")]
        public async Task<IActionResult> GetByDependencyIdAsync(int dependencyId)
        {
            try
            {
                return ApiResponse.SendSuccess("Clave Presupuestales recuperadas con éxito", await _budgetKeyDefaultService.GetByDependencyIdAsync(dependencyId));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en GetByDependencyIdAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // GET: api/BudgetKeyDefaults/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                return ApiResponse.SendSuccess("Clave Presupuestal recuperada con éxito", await _budgetKeyDefaultService.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en GetByIdAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // POST: api/BudgetKeyDefaults
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] BudgetKeyDefaultDto addressDto)
        {
            try
            {
                ValidationResult validationResult = await _validator.ValidateAsync(addressDto);

                if (!validationResult.IsValid)
                {
                    return ApiResponse.SendError("Error en los datos enviandos", validationResult.Errors, 400);
                }

                return ApiResponse.SendSuccess("Clave Presupuestal registrada con exito", await _budgetKeyDefaultService.CreateAsync(addressDto));
            }
            catch (Exception ex)
            {                
                return ApiResponse.SendError($"Excepción generada en PostBudgetKeyDefault: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // PUT: api/BudgetKeyDefaults/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] BudgetKeyDefaultDto addressDto)
        {
            try
            {
                ValidationResult validationResult = await _validator.ValidateAsync(addressDto);

                if (id != addressDto.Id)
                {
                    validationResult.Errors.Add(new ValidationFailure("Id", "El Id de la direccion no coincide con el Id proporcionado en la URL"));

                    return ApiResponse.SendError("Error en los datos enviandos", validationResult.Errors, 400);
                }

                if (!validationResult.IsValid)
                {
                    return ApiResponse.SendError("Error en los datos enviandos", validationResult.Errors, 400);
                }                

                return ApiResponse.SendSuccess("Clave Presupuestal actualizada exitosamente", await _budgetKeyDefaultService.UpdateAsync(id, addressDto));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en PutBudgetKeyDefault: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // DELETE: api/BudgetKeyDefaults/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await _budgetKeyDefaultService.DeleteAsync(id);

                return ApiResponse.SendSuccess("Clave Presupuestal eliminado exitosamente", false);
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en DeleteBudgetKeyDefault: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }
    }
}