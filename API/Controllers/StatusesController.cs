using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.StatusStore;

namespace API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StatusesController : ControllerBase
    {
        private StatusManager _statusManager;
        public StatusesController(StatusManager statusManager)
        {
            _statusManager = statusManager;
        }

        [Route("GetStatuses")]
        [HttpGet]
        public async Task<IActionResult> GetStatuses()
        {
            try
            {
                var statuses = await _statusManager.GetStatuses();

                return Ok(statuses);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [Route("CreateStatus")]
        [HttpPost]
        public async Task<IActionResult> CreateStatus(Status status)
        {
            try
            {
                var createdStatus = await _statusManager.CreateStatus(status);

                return Ok(createdStatus);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [Route("UpdateStatus")]
        [HttpPut]
        public async Task<IActionResult> UpdateStatus(Status status)
        {
            try
            {
                var updatedStatus = await _statusManager.UpdateStatus(status);

                return Ok(updatedStatus);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
