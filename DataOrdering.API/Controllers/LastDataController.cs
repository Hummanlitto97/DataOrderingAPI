using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

using DataOrdering.App;

namespace DataOrdering.API.Controllers
{
    [ApiController]
    [Route("/lastData")]
    public class LastDataController : ControllerBase
    {
        private readonly ILogger<LastDataController> _logger;
        private readonly IConfiguration configuration;

        public LastDataController(ILogger<LastDataController> logger, IConfiguration configuration)
        {
            _logger = logger;
            this.configuration = configuration;
        }
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { OrderingDataService.Load_Last_Ordered_Data(configuration.GetValue<string>("Databases:TextFile:Path")) };
        }
    }
}
