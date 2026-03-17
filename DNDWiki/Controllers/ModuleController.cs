using Microsoft.AspNetCore.Mvc;

namespace DNDWiki.Controllers
{

    [ApiController]
    [Route("")]
    public class ModuleController : ControllerBase
    {
        [HttpGet("module")]
        public string Get()
        {
            return "Module działa";
        }
    }

}
