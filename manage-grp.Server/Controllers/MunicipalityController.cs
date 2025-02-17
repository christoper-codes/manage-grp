using Microsoft.AspNetCore.Mvc;
using manage_grp.Server.Helpers;
using manage_grp.Server.Domain.Interfaces;

namespace manage_grp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MunicipalitiesController : ControllerBase
    {

        private readonly IMunicipalityRepository _municipalityRepository;

        public MunicipalitiesController(IMunicipalityRepository municipalityRepository)
        {
            _municipalityRepository = municipalityRepository;
        }

        // GET: api/Municipalities/State/1
        [HttpGet("State/{state_id}")]
        public async Task<IActionResult> GetByStateIdAsync(int state_id)
        {
            try
            {
                return ApiResponse.SendSuccess("Municipios recuperados con éxito", await _municipalityRepository.GetByStateIdAsync(state_id));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en GetByStateIdAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // GET: api/Municipalities/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                return ApiResponse.SendSuccess("Municipios recuperados con éxito", await _municipalityRepository.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en GetByIdAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }
    }
}