using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System;
using System.Net;

using DataOrdering.App;

namespace DataOrdering.API.Controllers
{
    [ApiController]
    [Route("/{type:alpha}/{data}")]
    public class DataOrderingController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<DataOrderingController> _logger;
        public DataOrderingController(ILogger<DataOrderingController> logger, IConfiguration configuration)
        {
            _logger = logger;
            this.configuration = configuration;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            try
            {
                return OrderingDataService.Sort_Data(
                                                        (string)HttpContext.Request.RouteValues["data"],
                                                        (string)HttpContext.Request.RouteValues["type"],
                                                        configuration.GetValue<string>("Databases:TextFile:Path"));
            }
            catch(NotImplementedException nie)
            {
                Response.StatusCode = (int)HttpStatusCode.NotImplemented;
                return new string[] { nie.Message };

            }
            catch(Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return new string[] { string.Empty };
            }
        }
    }
}
