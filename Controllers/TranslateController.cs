using AngularDotNet.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace AngularDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranslateController : ControllerBase
    {

        [HttpPost]
        [Route("{json}")]
        [Consumes("application/xml")]
        public IActionResult Post(Organization organization)
        {
            return Ok();
        }
    }
}
