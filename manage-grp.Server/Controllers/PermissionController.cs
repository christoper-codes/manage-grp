using manage_grp.Server.Domain.Services;
using manage_grp.Server.Enums;
using manage_grp.Server.Helpers;

using Microsoft.AspNetCore.Mvc;

namespace manage_grp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly PermissionService _permissionService;

        public PermissionController(PermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        // GET: api/Permission/State
        [HttpGet("/{hierarchyLevel}")]
        public async Task<IActionResult> GetByHierarchyAsync(string hierarchyLevel)
        {
            try
            {
                return ApiResponse.SendSuccess("Permisos recuperadas con éxito", await _permissionService.GetByHierarchyAsync(hierarchyLevel));
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError($"Excepción generada en GetByStateAsync: {ex.Message}|{ex.InnerException?.Message ?? ""}", false, 500);
            }
        }
    }
}