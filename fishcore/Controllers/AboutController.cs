using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace fishcore.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly ILogger<AboutController> _logger;

        public AboutController(ILogger<AboutController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            About result = new About();
            result.Test = "FishCore is an application designed to allow users to generate pychometric assessments for use in the Fish Dreams Assessment Tracker.";
            return JsonSerializer.Serialize(result.Test);
        }
    }
}
