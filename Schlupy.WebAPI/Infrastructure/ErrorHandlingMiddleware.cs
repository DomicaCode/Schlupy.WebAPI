using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Schlupy.Model.Response;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Schlupy.WebAPI.Infrastructure
{
    public class ErrorHandlingMiddleware
    {
        #region Fields

        private readonly RequestDelegate next;

        #endregion Fields

        #region Constructors

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        #endregion Constructors

        #region Methods

        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            //var code = HttpStatusCode.InternalServerError;

            //if (ex is MyNotFoundException) code = HttpStatusCode.NotFound;
            //else if (ex is MyUnauthorizedException) code = HttpStatusCode.Unauthorized;
            //else if (ex is ) code = HttpStatusCode.BadRequest;

            var response = new BaseResponse
            {
                Error = ex.Message,
                IsSuccess = false,
            };

            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            var result = JsonConvert.SerializeObject(response, serializerSettings);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError);
            return context.Response.WriteAsync(result);
        }

        #endregion Methods
    }
}