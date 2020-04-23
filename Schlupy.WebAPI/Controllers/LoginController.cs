using Microsoft.AspNetCore.Mvc;
using Schlupy.Service.Common.Services.Membership;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Schlupy.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        #region Constructors

        public LoginController(ILoginService loginService)
        {
            LoginService = loginService;
        }

        #endregion Constructors

        #region Properties

        protected ILoginService LoginService { get; }

        #endregion Properties

        #region Methods

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginInfo model)
        {
            var token = await LoginService.LoginAsync(model.Username, model.Password);

            if (token != null)
            {
                return Ok(token);
            }

            return BadRequest();
        }

        #endregion Methods
    }

    public class LoginInfo
    {
        #region Properties

        [Required]
        public string Password { get; set; }

        [Required]
        public string Username { get; set; }

        #endregion Properties
    }
}