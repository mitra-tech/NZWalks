using System.Net;

namespace NZWalksAPI.Middlewares
{
    public class ExceptionHandlerMiddlewares
    {

        private readonly ILogger<ExceptionHandlerMiddlewares> logger;
        private readonly RequestDelegate next;
        public ExceptionHandlerMiddlewares(ILogger<ExceptionHandlerMiddlewares> logger, RequestDelegate next)
        {
            this.logger = logger;
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex) 
            {
                var errorId = Guid.NewGuid();

                // Log This Exception
                logger.LogError(ex, $"{errorId}: {ex.Message}" );

                // Return A Custom Error Response
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "application/json";

                var error = new
                {
                    Id = errorId,
                    ErrorMessage = "Something went wrong! We are working hard to fix it."
                };

                await httpContext.Response.WriteAsJsonAsync( error );

                throw;
            }
        }

    }
}
