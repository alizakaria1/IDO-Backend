using Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EnumsController : ControllerBase
    {
        [Route("GetImportanceEnum")]
        [HttpGet]
        public ActionResult<string[]> GetImportanceEnum()
        {
            var priorities = Enum.GetNames(typeof(Importance.Priority));
            return Ok(priorities);
        }

        [Route("GetTimeFrameEnum")]
        [HttpGet]
        public ActionResult<string[]> GetTimeFrameEnum()
        {
            var times = Enum.GetNames(typeof(TimeFrame.Time));
            return Ok(times);
        }
    }
}
