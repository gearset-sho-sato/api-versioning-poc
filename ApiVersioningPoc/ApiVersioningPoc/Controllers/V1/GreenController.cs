using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiVersioningPoc.Controllers.V1
{
    [ApiController]
    [ApiVersion(version1_0)]
    public class GreenController : ControllerBase
    {
        private readonly ILogger<GreenController> logger;
        private const string version1_0 = "1.0";

        public GreenController(ILogger<GreenController> logger)
        {
            this.logger = logger;
        }

        [HttpGet, Route("public/green")]
        [MapToApiVersion(version1_0)]
        public ActionResult<string> GetVersion1_0()
        {
            return Ok($"{nameof(GreenController)} {nameof(GetVersion1_0)}");
        }
    }
}