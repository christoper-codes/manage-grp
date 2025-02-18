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
    public class TenderFundingSourceController : ControllerBase
    {
        private readonly TenderFundingSourceService _tenderFundingSourceService;
        private readonly IValidator<TenderFundingSourceDto> _validator;

        public TenderFundingSourceController(TenderFundingSourceService tenderFundingSourceService, IValidator<TenderFundingSourceDto> validator)
        {
            _tenderFundingSourceService = tenderFundingSourceService;
            _validator = validator;
        }

        // GET: api/TenderFundingSources/Dependency/1
        [HttpGet("Dependency/{dependencyId}")]
        public async Task<IActionResult> GetByDependencyAsync(int dependencyId)
        {
            try
            {
                return ApiResponse.SendSuccess("Origenes de recurso para licitacion recuperados con éxito", await _tenderFundingSourceService.GetByDependencyAsync(dependencyId));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en GetByDependencyAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // GET: api/TenderFundingSources/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                return ApiResponse.SendSuccess("Origen de recurso para licitacion recuperado con éxito", await _tenderFundingSourceService.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en GetByIdAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // POST: api/TenderFundingSources
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] TenderFundingSourceDto tenderFundingSourceDto)
        {
            try
            {
                ValidationResult validationResult = await _validator.ValidateAsync(tenderFundingSourceDto);

                if (!validationResult.IsValid)
                {
                    return ApiResponse.SendError("Error en los datos enviados", validationResult.Errors, 400);
                }

                return ApiResponse.SendSuccess("Origen de recurso para licitacion registrada con éxito", await _tenderFundingSourceService.CreateAsync(tenderFundingSourceDto));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en CreateAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // PUT: api/TenderFundingSources/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] TenderFundingSourceDto tenderFundingSourceDto)
        {
            try
            {
                ValidationResult validationResult = await _validator.ValidateAsync(tenderFundingSourceDto);

                if (id != tenderFundingSourceDto.Id)
                {
                    validationResult.Errors.Add(new ValidationFailure("Id", "El Id del origen de recurso para licitacion no coincide con el Id proporcionado en la URL"));

                    return ApiResponse.SendError("Error en los datos enviados", validationResult.Errors, 400);
                }

                if (!validationResult.IsValid)
                {
                    return ApiResponse.SendError("Error en los datos enviados", validationResult.Errors, 400);
                }

                return ApiResponse.SendSuccess("Origen de recurso para licitacion actualizado exitosamente", await _tenderFundingSourceService.UpdateAsync(id, tenderFundingSourceDto));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en UpdateAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // DELETE: api/TenderFundingSources/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await _tenderFundingSourceService.DeleteAsync(id);

                return ApiResponse.SendSuccess("Origen de recurso para licitacion eliminado exitosamente", false);
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en DeleteAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }
    }
}