using fishcore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Text.Json;

namespace fishcore.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AssessmentComponentController : ControllerBase
    {
        private readonly ILogger<AboutController> _logger;

        public AssessmentComponentController(ILogger<AboutController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            List<AssessmentComponent> result = new List<AssessmentComponent>
            {
                new AssessmentComponent
                {
                    Name = "Start",
                    Description = "This component starts things.",
                    Direction = "input"
                },

                new AssessmentComponent
                {
                    Name = "Action",
                    Description = "This component does a thing.",
                    Direction = "default"
                },

                new AssessmentComponent
                {
                    Name = "Non Action",
                    Description = "This component does a thing.",
                    Direction = "default"
                },

                new AssessmentComponent
                {
                    Name = "End",
                    Description = "This component ends things.",
                    Direction = "output"
                },

                new AssessmentComponent
                {
                    Name = "Another",
                    Description = "This component ends things.",
                    Direction = "output"
                }
            };

            return JsonSerializer.Serialize(result);
        }
    }
}
