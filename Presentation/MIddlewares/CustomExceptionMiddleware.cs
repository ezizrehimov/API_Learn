using Business.Exceptions;
using Business.Services.Common;
using System.Text.Json;

namespace Presentation.MIddlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate next;

        public CustomExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                await Handle(e, context);
            }
        }


        public async Task Handle(Exception e, HttpContext context)
        {

            context.Response.ContentType = "application/json";
            Response response = new Response();
            switch (e)
            {
                case ValidatorException ex:
                    response.Errors = ex.Errors;
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                    break;
                case NotFoundException ex:
                    response.Errors = ex.Errors;
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                    break;
                default:
                    break;
            }
        }



    }
}
