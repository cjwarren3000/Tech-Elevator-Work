using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestWebApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class XyzzyController : ControllerBase
    {
        // GET values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value3", "value4" };
        }
    }
}