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
    public class ContactController : ControllerBase
    {
        private readonly ContactService _contactService;
        private readonly IValidator<ContactDto> _validator;

        public ContactController(ContactService contactService, IValidator<ContactDto> validator)
        {
            _contactService = contactService;
            _validator = validator;
        }

        // GET: api/Contacts/Dependency/1
        [HttpGet("Dependency/{dependencyId}")]
        public async Task<IActionResult> GetByDependencyAsync(int dependencyId)
        {
            try
            {
                return ApiResponse.SendSuccess("Contactos recuperadas con éxito", await _contactService.GetByDependencyAsync(dependencyId));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en GetByDependencyAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // GET: api/Contacts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                return ApiResponse.SendSuccess("Contacto recuperada con éxito", await _contactService.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en GetByIdAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // POST: api/Contacts
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ContactDto contactDto)
        {
            try
            {
                ValidationResult validationResult = await _validator.ValidateAsync(contactDto);

                if (!validationResult.IsValid)
                {
                    return ApiResponse.SendError("Error en los datos enviandos", validationResult.Errors, 400);
                }

                return ApiResponse.SendSuccess("Contacto registrada con exitoso", await _contactService.CreateAsync(contactDto));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en CreateAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // PUT: api/Contacts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] ContactDto contactDto)
        {
            try
            {
                ValidationResult validationResult = await _validator.ValidateAsync(contactDto);

                if (id != contactDto.Id)
                {
                    validationResult.Errors.Add(new ValidationFailure("Id", "El Id del contacto no coincide con el Id proporcionado en la URL"));

                    return ApiResponse.SendError("Error en los datos enviandos", validationResult.Errors, 400);
                }

                if (!validationResult.IsValid)
                {
                    return ApiResponse.SendError("Error en los datos enviandos", validationResult.Errors, 400);
                }                

                return ApiResponse.SendSuccess("Contacto actualizada exitosamente", await _contactService.UpdateAsync(id, contactDto));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en UpdateAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // DELETE: api/Contacts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            try
            {
                await _contactService.DeleteAsync(id);

                return ApiResponse.SendSuccess("Contacto eliminado exitosamente", false);
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en DeleteAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }
    }
}