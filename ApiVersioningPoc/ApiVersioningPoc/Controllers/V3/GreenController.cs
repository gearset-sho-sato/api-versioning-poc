using ApiVersioningPoc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiVersioningPoc.Controllers.V3
{
    [ApiController]
    [ApiVersion(version3_0)]
    public class GreenController : ControllerBase
    {
        private readonly ILogger<GreenController> logger;
        private const string version3_0 = "3.0";

        public GreenController(ILogger<GreenController> logger)
        {
            this.logger = logger;
        }

        [HttpGet, Route("public/green")]
        [MapToApiVersion(version3_0)]
        public ActionResult<Version> GetVersion3_0()
        {
            return Ok(new Version($"{nameof(GreenController)} {nameof(GetVersion3_0)}"));
        }
    }
}