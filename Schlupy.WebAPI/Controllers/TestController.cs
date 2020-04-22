using Microsoft.AspNetCore.Mvc;

namespace Schlupy.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        #region Methods

        [HttpGet]
        [Route("test")]
        public IActionResult Test()
        {
            return Ok(new { vanjaisGay = true });
        }

        #endregion Methods
    }
}