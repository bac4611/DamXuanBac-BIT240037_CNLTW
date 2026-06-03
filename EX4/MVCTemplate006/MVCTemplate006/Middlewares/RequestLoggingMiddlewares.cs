namespace MVCTemplate006.Middlewares;

public class RequestLoggingMiddlewares
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddlewares> _logger;

    public RequestLoggingMiddlewares(
        RequestDelegate next,
        ILogger<RequestLoggingMiddlewares> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var startedAt = DateTime.Now;
        var method = context.Request.Method;
        var path = context.Request.Path.ToString();

        _logger.LogInformation(
            "Request started at {StartedAt}: {Method} {Path}",
            startedAt.ToString("yyyy-MM-dd HH:mm:ss"),
            method,
            path);

        if (path == "/Book/Detail/0" || path == "/Book/Detail/-1")
        {
            context.Response.StatusCode = 400;
            _logger.LogWarning(
                "Rejected invalid book detail request: {Method} {Path}",
                method,
                path);

            await context.Response.WriteAsync("Book id khong hop le");
            return;
        }

        await _next(context);

        _logger.LogInformation(
            "Request finished: {Method} {Path} responded {StatusCode}",
            method,
            path,
            context.Response.StatusCode);
    }
}
