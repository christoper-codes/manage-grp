using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using manage_grp.Server.Context;
using manage_grp.Server.Models;
using manage_grp.Server.Dominian.Services;
using manage_grp.Server.Helpers;

namespace manage_grp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MunicipalityController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly MunicipalityService _municipalityService;

        public MunicipalityController(AppDbContext context, MunicipalityService municipalityService)
        {
            _context = context;
            _municipalityService = municipalityService;
        }

        // GET: api/Municipality
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var municipalities = await Task.Run(() => _municipalityService.GetAll());

                return ApiResponse.SendSuccess("Municipios recuperados con éxito", municipalities);

            }
            catch (Exception ex)
            {
                return ApiResponse.SendError(ex.Message, false, 500);
            }

        }

        // GET: api/Municipality/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Municipality>> GetMunicipality(int id)
        {
            var municipality = await _context.Municipalities.FindAsync(id);

            if (municipality == null)
            {
                return NotFound();
            }

            return municipality;
        }

        // PUT: api/Municipality/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Models.Municipality municipality)
        {
            try
            {
                await Task.Run(() => _municipalityService.Update(id, municipality));
                return ApiResponse.SendSuccess("Municipio actualizado exitosamente", municipality);
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError(ex.Message, false, 500);
            }
        }

        // POST: api/Municipality
        [HttpPost]
        public async Task<IActionResult> Save(Models.Municipality municipality)
        {
            try
            {
                await Task.Run(() => _municipalityService.Save(municipality));

                return ApiResponse.SendSuccess("Municipio guardado exitosamente", municipality);
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError(ex.Message, false, 500);
            }
        }

        // DELETE: api/Municipality/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await Task.Run(() => _municipalityService.Delete(id));
                return ApiResponse.SendSuccess("Municipio eliminado exitosamente", false);
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError(ex.Message, false, 500);
            }
        }
    }
}
