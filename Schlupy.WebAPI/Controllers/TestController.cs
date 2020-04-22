using Microsoft.AspNetCore.Mvc;
using Schlupy.WebAPI.Controllers.Base;

namespace Schlupy.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : BaseController
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