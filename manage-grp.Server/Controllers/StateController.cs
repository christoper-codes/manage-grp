using Microsoft.AspNetCore.Mvc;
using manage_grp.Server.Domain.Services;
using manage_grp.Server.Helpers;

namespace manage_grp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatesController : ControllerBase
    {

        private readonly StateService _stateService;

        public StatesController(StateService stateService)
        {
            _stateService = stateService;
        }

        // GET: api/States
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                return ApiResponse.SendSuccess("Estados recuperados con éxito", await _stateService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en GetAllAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }

        // GET: api/States/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                return ApiResponse.SendSuccess("Estados recuperados con éxito", await _stateService.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en GetByIdAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }
    }
}
