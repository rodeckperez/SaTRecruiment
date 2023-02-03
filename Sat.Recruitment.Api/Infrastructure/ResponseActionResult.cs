using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sat.Recruiment.Common.Utils;
using System.Text.Json.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;

namespace Sat.Recruitment.Api.Infrastructure
{
    public class ResponseActionResult : IActionResult
    {
        public ResponseActionResult(Response response)
        {
            this.Response = response;
        }

        public Response Response { get; private set; }

        public static IActionResult CreateActionResult(Response response)
        {
            return new ResponseActionResult(response);
        }

        public Task ExecuteResultAsync(ActionContext actionContext)
        {
            return this.ExecuteResultAsync(actionContext.HttpContext);
        }

        public Task ExecuteResultAsync(HttpContext context)
        {
            this.SetContentType(context);
            this.SetHttpStatusCode(context);
            return context.Response.WriteAsync(JsonConvert.SerializeObject(this.Response), Encoding.UTF8);
        }

        private void SetContentType(HttpContext context)
        {
            context.Response.ContentType = "application/json; charset=utf-8";
        }

        private void SetHttpStatusCode(HttpContext context)
        {
            var statusCode = (int)HttpStatusCode.OK;

            if (this.Response.HasErrors)
            {
                statusCode = (int)HttpStatusCode.BadRequest;

                if (this.Response.HasInternalServerError)
                {
                    statusCode = (int)HttpStatusCode.InternalServerError;
                }
            }

            context.Response.StatusCode = statusCode;
        }
    }
}
