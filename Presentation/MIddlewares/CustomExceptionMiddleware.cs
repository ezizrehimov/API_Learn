using Business.Exceptions;
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
            switch (e)
            {
                case ValidatorException ex:
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    await context.Response.WriteAsync(JsonSerializer.Serialize(ex.Errors));
                    break;
                default:
                    break;
            }
        }



    }
}
