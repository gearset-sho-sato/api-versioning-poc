using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace ApiVersioningPoc.Controllers
{
    [ApiController]
    [ApiVersion(version1_0, Deprecated = true)]
    [ApiVersion(version1_1, Deprecated = true)]
    [ApiVersion(version2_0)]
    public class BlueController : ControllerBase
    {
        private readonly ILogger<BlueController> logger;
        private const string version1_0 = "1.0";
        private const string version1_1 = "1.1";
        private const string version2_0 = "2.0";

        public BlueController(ILogger<BlueController> logger)
        {
            this.logger = logger;
        }

        [HttpGet, Route("public/blue")]
        [MapToApiVersion(version1_0)]
        [Obsolete]
        public ActionResult<string> GetVersion1_0()
        {
            return Ok($"{nameof(BlueController)} {nameof(GetVersion1_0)}");
        }

        [HttpGet, Route("public/blue")]
        [MapToApiVersion(version1_1)]
        [Obsolete]
        public ActionResult<string> GetVersion1_1()
        {
            logger.LogError("Logging...");
            return Ok($"{nameof(BlueController)} {nameof(GetVersion1_1)}");
        }

        [HttpGet, Route("public/blue")]
        [MapToApiVersion(version2_0)]
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