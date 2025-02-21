using FluentValidation;
using FluentValidation.Results;
using manage_grp.Server.Domain.Services;
using manage_grp.Server.DTOs;
using manage_grp.Server.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace repro_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenderController : ControllerBase
    {
        private readonly TenderService _tenderService;
        private readonly IValidator<TenderDto> _validator;

        public TenderController(TenderService tenderService, IValidator<TenderDto> validator)
        {
            _tenderService = tenderService;
            _validator = validator;
        }

        // GET: api/Tenders/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                return ApiResponse.SendSuccess("Licitacion recuperada con éxito", await _tenderService.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en GetByIdAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // POST: api/Tenders
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] TenderDto tenderDto)
        {
            try
            {
                ValidationResult validationResult = await _validator.ValidateAsync(tenderDto);

                if (!validationResult.IsValid)
                {
                    return ApiResponse.SendError("Error en los datos enviandos", validationResult.Errors, 400);
                }

                return ApiResponse.SendSuccess("Licitacion registrada con exito", await _tenderService.CreateAsync(tenderDto));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en CreateAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // PUT: api/Tenders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] TenderDto tenderDto)
        {
            try
            {
                ValidationResult validationResult = await _validator.ValidateAsync(tenderDto);

                if (id != tenderDto.Id)
                {
                    validationResult.Errors.Add(new ValidationFailure("Id", "El Id de la Licitacion no coincide con el Id proporcionado en la URL"));

                    return ApiResponse.SendError("Error en los datos enviandos", validationResult.Errors, 400);
                }

                if (!validationResult.IsValid)
                {
                    return ApiResponse.SendError("Error en los datos enviandos", validationResult.Errors, 400);
                }                

                return ApiResponse.SendSuccess("Licitacion actualizada exitosamente", await _tenderService.UpdateAsync(id, tenderDto));
            }
            catch (Exception ex)
            {               
                return ApiResponse.SendError($"Excepción generada en UpdateAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // DELETE: api/Tenders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleAsync(int id)
        {
            try
            {
                await _tenderService.DeleAsync(id);

                return ApiResponse.SendSuccess("Licitacion eliminado exitosamente", false);
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en DeleAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }
    }
}