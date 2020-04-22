using Microsoft.AspNetCore.Mvc;

namespace Schlupy.WebAPI.Controllers.Base
{
    public class BaseController : ControllerBase
    {
        #region Fields

        private readonly string _apiBase = "api";

        private readonly string _apiVersion = "v1";

        #endregion Fields

        #region Properties

        protected string BaseRoute { get { return $"{_apiBase}/{_apiVersion}"; } }

        #endregion Properties
    }
}