using community_institute_API.Errors;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace community_institute_API.Midelware
{
    public class ExptionMidelWare
    {
        //adding exption midelware 
        private readonly RequestDelegate next;
        private readonly ILogger<ExptionMidelWare> logger;
        private readonly IHostEnvironment host;

        public ExptionMidelWare(RequestDelegate Next, ILogger<ExptionMidelWare> Logger, IHostEnvironment Host)
        {
            next = Next;
            logger = Logger;
            host = Host;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (System.Exception Ex)
            {
                logger.LogError(Ex, Ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var errorRespons = host.IsDevelopment() ?
                    new ApiExptionRespons((int)HttpStatusCode.InternalServerError, Ex.Message, Ex.StackTrace) :
                    new ApiExptionRespons((int)HttpStatusCode.InternalServerError);
                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var json = JsonSerializer.Serialize(errorRespons, options);
                await context.Response.WriteAsync(json);




            }
        }
        
    }
}
