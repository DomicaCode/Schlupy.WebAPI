using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Schlupy.Model.Models.Clock;
using Schlupy.Service.Common.Services.Clock;
using Schlupy.WebAPI.Controllers.Base;
using System;
using System.Threading.Tasks;

namespace Schlupy.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClockController : BaseController
    {
        #region Constructors

        public ClockController(IClockService clockService)
        {
            ClockService = clockService;
        }

        #endregion Constructors

        #region Properties

        public IClockService ClockService { get; }

        #endregion Properties

        #region Methods

        [HttpGet]
        [Route("start/{userId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> StartClock(Guid userId)
        {
            if (userId.Equals(Guid.Empty))
            {
                return BadRequest();
            }

            if (!Guid.Parse(GetUserId()).Equals(userId))
            {
                return Unauthorized();
            }

            var response = await ClockService.InsertAsync(new ClockEntry(), userId);

            return Ok(response);
        }

        #endregion Methods
    }
}