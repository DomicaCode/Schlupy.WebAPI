using System.Net;

namespace Schlupy.Model.Response
{
    public class BaseResponse
    {
        #region Properties

        public string Error { get; set; }

        public bool? IsSuccess { get; set; }
        public string Message { get; set; }

        #endregion Properties
    }
}