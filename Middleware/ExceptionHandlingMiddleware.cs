using Serilog;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Unhandled exception!");
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("En feil oppstod, prøv igjen senere"+ ex.Message);
        }
    }
}