using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace THA.Search.Mocks
{
    public sealed class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly ILogger _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger logger = null)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Error occured.");

                throw;
            }
        }
    }
}