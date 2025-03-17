using System;

namespace VKKirana.Middlewares;

public class LoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<LoggingMiddleware> _logger;

    public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;

    }

    public async Task Invoke(HttpContext context)
    {
        _logger.LogInformation("Request: " + context.Request.Path);
        await _next(context);
    }

}
