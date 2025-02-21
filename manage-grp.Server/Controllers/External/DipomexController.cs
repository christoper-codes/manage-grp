
using manage_grp.Server.Domain.Services;
using manage_grp.Server.Domain.Services.External;
using manage_grp.Server.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace manage_grp.Server.Controllers.External
{
    [Route("api/[controller]")]
    [ApiController]
    public class DipomexController : ControllerBase
    {
        private readonly DipomexService _dipomexService;

        public DipomexController(DipomexService dipomexService, StateService stateService)
        {
            _dipomexService = dipomexService;
        }

        // GET: api/Dipomex/States
        [HttpGet("States")]
        public async Task<IActionResult> GetAllStatesAndSaveAsync()
        {
            try
            {
                return ApiResponse.SendSuccess("Estados registrada con exito", await _dipomexService.GetAllStatesAsync());
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en GetAllStatesAndSaveAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // GET: api/Dipomex/Municipalities
        [HttpGet("Municipalities")]
        public async Task<IActionResult> GetAllMunicipalitiesAndSaveAsync()
        {
            try
            {
                return ApiResponse.SendSuccess("Municipios registrada con exito", await _dipomexService.GetAllMunicipalitiesAsync());
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en GetAllMunicipalitiesAndSaveAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }
    }
}