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
    public class BudgetaryKeyDocumentTypeController : ControllerBase
    {
        private readonly BudgetaryKeyDocumentTypeService _budgetaryKeyDocumentTypeService;
        private readonly IValidator<BudgetaryKeyDocumentTypeDto> _validator;

        public BudgetaryKeyDocumentTypeController(BudgetaryKeyDocumentTypeService budgetaryKeyDocumentTypeService, IValidator<BudgetaryKeyDocumentTypeDto> validator)
        {
            _budgetaryKeyDocumentTypeService = budgetaryKeyDocumentTypeService;
            _validator = validator;
        }

        // GET: api/BudgetaryKeyDocumentTypes/Dependency/1
        [HttpGet("Dependency/{dependencyId}")]
        public async Task<IActionResult> GetByDependencyIdAsync(int dependencyId)
        {
            try
            {
                return ApiResponse.SendSuccess("Tipos de documentos recuperados con éxito", await _budgetaryKeyDocumentTypeService.GetByDependencyIdAsync(dependencyId));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en GetByDependencyIdAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // GET: api/BudgetaryKeyDocumentTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                return ApiResponse.SendSuccess("Tipos de documento recuperado con éxito", await _budgetaryKeyDocumentTypeService.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en GetByIdAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // POST: api/BudgetaryKeyDocumentTypes
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] BudgetaryKeyDocumentTypeDto budgetaryKeyDocumentTypeDto)
        {
            try
            {
                ValidationResult validationResult = await _validator.ValidateAsync(budgetaryKeyDocumentTypeDto);

                if (!validationResult.IsValid)
                {
                    return ApiResponse.SendError("Error en los datos enviandos", validationResult.Errors, 400);
                }

                return ApiResponse.SendSuccess("Tipo de documento registrada con exito", await _budgetaryKeyDocumentTypeService.CreateAsync(budgetaryKeyDocumentTypeDto));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en CreateAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // PUT: api/BudgetaryKeyDocumentTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] BudgetaryKeyDocumentTypeDto budgetaryKeyDocumentTypeDto)
        {
            try
            {
                ValidationResult validationResult = await _validator.ValidateAsync(budgetaryKeyDocumentTypeDto);

                if (id != budgetaryKeyDocumentTypeDto.Id)
                {
                    validationResult.Errors.Add(new ValidationFailure("Id", "El Id del tipo de documento no coincide con el Id proporcionado en la URL"));

                    return ApiResponse.SendError("Error en los datos enviandos", validationResult.Errors, 400);
                }

                if (!validationResult.IsValid)
                {
                    return ApiResponse.SendError("Error en los datos enviandos", validationResult.Errors, 400);
                }                

                return ApiResponse.SendSuccess("Tipo de documento actualizado exitosamente", await _budgetaryKeyDocumentTypeService.UpdateAsync(id, budgetaryKeyDocumentTypeDto));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en PutBudgetaryKeyDocumentType: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // DELETE: api/BudgetaryKeyDocumentTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await _budgetaryKeyDocumentTypeService.DeleteAsync(id);

                return ApiResponse.SendSuccess("Direccion eliminado exitosamente", false);
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en DeleteBudgetaryKeyDocumentType: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }
    }
}