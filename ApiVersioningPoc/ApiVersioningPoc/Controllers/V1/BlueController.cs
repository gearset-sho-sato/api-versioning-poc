using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace ApiVersioningPoc.Controllers.V1
{
    [ApiController]
    [ApiVersion(version1_0, Deprecated = true)]
    [ApiVersion(version1_1, Deprecated = true)]
    [Obsolete]
    public class BlueController : ControllerBase
    {
        private readonly ILogger<BlueController> logger;
        private const string version1_0 = "1.0";
        private const string version1_1 = "1.1";

        public BlueController(ILogger<BlueController> logger)
        {
            this.logger = logger;
        }

        [HttpGet, Route("public/blue")]
        [MapToApiVersion(version1_0)]
        public ActionResult<string> GetVersion1_0()
        {
            return Ok($"{nameof(BlueController)} {nameof(GetVersion1_0)}");
        }

        [HttpGet, Route("public/blue")]
        [MapToApiVersion(version1_1)]
        public ActionResult<string> GetVersion1_1()
        {
            logger.LogError("Logging...");
            return Ok($"{nameof(BlueController)} {nameof(GetVersion1_1)}");
        }

        [HttpPost, Route("public/blue")]
        public ActionResult<Models.Version> Post(Models.Version version)
        {
            return version;
        }
    }
}