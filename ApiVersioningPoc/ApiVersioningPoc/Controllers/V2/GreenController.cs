using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiVersioningPoc.Controllers.V2
{
    [ApiController]
    [ApiVersion(version2_0)]
    public class GreenController : ControllerBase
    {
        private readonly ILogger<GreenController> logger;
        private const string version2_0 = "2.0";

        public GreenController(ILogger<GreenController> logger)
        {
            this.logger = logger;
        }

        [HttpGet, Route("public/green")]
        [MapToApiVersion(version2_0)]
        public ActionResult<object> GetVersion2_0()
        {
            return Ok(new { message = $"{nameof(GreenController)} {nameof(GetVersion2_0)}" });
        }
    }
}