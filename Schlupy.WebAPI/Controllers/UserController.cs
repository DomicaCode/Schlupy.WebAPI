using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Schlupy.Model.Models;
using Schlupy.Service.Common.Services.Membership;
using Schlupy.WebAPI.Models;
using System.Threading.Tasks;

namespace Schlupy.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region Constructors

        public UserController(IUserService userService, IMapper mapper)
        {
            UserService = userService;
            Mapper = mapper;
        }

        #endregion Constructors

        #region Properties

        private IMapper Mapper { get; }
        private IUserService UserService { get; }

        #endregion Properties

        #region Methods

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegistrationViewModel model)
        {
            var user = Mapper.Map<User>(model);

            var response = await UserService.RegisterAsync(user);

            return Ok(response);
        }

        #endregion Methods
    }
}