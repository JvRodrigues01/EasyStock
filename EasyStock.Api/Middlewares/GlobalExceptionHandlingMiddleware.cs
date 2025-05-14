using System.Net;
using System.Text.Json;
using EasyStock.SharedKernel.Core.Base;
using EasyStock.SharedKernel.Core.Exceptions;

namespace EasyStock.Api.Middlewares
{
    public class GlobalExceptionHandlingMiddleware : IMiddleware
    {
        protected readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;
        public GlobalExceptionHandlingMiddleware(ILogger<GlobalExceptionHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (AuthoritativeException ex)
            {
                context.Response.StatusCode = ex.Code;
                var response = new BaseResult<object>(null, false, ex.Message);
                HandleException(response, context);
            }
            catch (NotFoundException ex)
            {
                context.Response.StatusCode = ex.Code;
                var response = new BaseResult<object>(null, false, ex.Message);
                HandleException(response, context);
            }
            catch (ErrorException ex)
            {
                context.Response.StatusCode = ex.Code;
                var response = new BaseResult<object>(null, false, ex.Message);
                HandleException(response, context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var response = new BaseResult<object>(null, false, ex.Message);
                HandleException(response, context);
            }
        }

        private async void HandleException(BaseResult<object> response, HttpContext context)
        {
            _logger.LogError($"[GlobalHandlingException] - Exception: {response.Message}");
            string json = JsonSerializer.Serialize(response, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            });

            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(json);
        }
    }
}
