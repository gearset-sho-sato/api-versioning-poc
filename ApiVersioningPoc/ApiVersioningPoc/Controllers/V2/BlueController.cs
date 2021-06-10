using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiVersioningPoc.Controllers.V2
{
    [ApiController]
    [ApiVersion(version2_0)]
    public class BlueController : ControllerBase
    {
        private readonly ILogger<BlueController> logger;
        private const string version2_0 = "2.0";

        public BlueController(ILogger<BlueController> logger)
        {
            this.logger = logger;
        }

        [HttpGet, Route("public/blue")]
        public ActionResult<Models.Version> GetVersion2_0()
        {
            return Ok(new Models.Version($"{nameof(BlueController)} {nameof(GetVersion2_0)}"));
        }

        [HttpPost, Route("public/blue")]
        public ActionResult<Models.Version> Post(Models.Version version)
        {
            return version;
        }
    }
}