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
using Mono.TextTemplating;

namespace manage_grp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly StateService _stateService;

        public StateController(AppDbContext context, StateService stateService)
        {
            _context = context;
            _stateService = stateService;
        }

        // GET: api/State
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var states = await Task.Run(() => _stateService.GetAll());
               
                return ApiResponse.SendSuccess("Estados recuperados con éxito", states);

            }
            catch (Exception ex)
            {
                return ApiResponse.SendError(ex.Message, false, 500);
            }

        }


        // GET: api/State/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var state = await Task.Run(() => _stateService.GetById(id));
                return ApiResponse.SendSuccess("Estados recuperados con éxito", state);
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError(ex.Message, false, 500);
            }
        }

        // PUT: api/State/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Models.State state)
        {
            try
            {
                await Task.Run(() => _stateService.Update(id, state));
                return ApiResponse.SendSuccess("Estado actualizado exitosamente", state);
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError(ex.Message, false, 500);
            }
        }


        // POST: api/State
        [HttpPost]
        public async Task<IActionResult> Save(Models.State state)
        {
            try
            {
                //validator

                await Task.Run(() => _stateService.Save(state));

                return ApiResponse.SendSuccess("Estado guardado exitosamente", state);
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError(ex.Message, false, 500);
            }
        }

        // DELETE: api/State/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await Task.Run(() => _stateService.Delete(id));
                return ApiResponse.SendSuccess("Estado eliminado exitosamente", false);
            }
            catch (Exception ex)
            {
                return ApiResponse.SendError(ex.Message, false, 500);
            }
        }
    }
}
