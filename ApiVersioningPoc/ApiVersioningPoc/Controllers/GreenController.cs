using ApiVersioningPoc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiVersioningPoc.Controllers
{
    [ApiController]
    [ApiVersion(version1_0)]
    [ApiVersion(version2_0)]
    [ApiVersion(version3_0)]
    public class GreenController : ControllerBase
    {
        private readonly ILogger<GreenController> logger;
        private const string version1_0 = "1.0";
        private const string version2_0 = "2.0";
        private const string version3_0 = "3.0";

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

        [HttpGet, Route("public/green")]
        [MapToApiVersion(version2_0)]
        public ActionResult<object> GetVersion2_0()
        {
            return Ok(new { message = $"{nameof(GreenController)} {nameof(GetVersion2_0)}" });
        }

        [HttpGet, Route("public/green")]
        [MapToApiVersion(version3_0)]
        public ActionResult<Version> GetVersion3_0()
        {
            return Ok(new Version($"{nameof(GreenController)} {nameof(GetVersion3_0)}"));
        }
    }
}