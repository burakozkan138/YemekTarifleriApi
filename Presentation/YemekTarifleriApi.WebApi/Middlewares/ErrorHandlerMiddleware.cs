using System.Net;
using System.Net.Mime;
using System.Text.Json;

namespace YemekTarifleriApi.WebApi.Middlewares;

public class ErrorHandlerMiddleware
{
  readonly RequestDelegate _next;

  public ErrorHandlerMiddleware(RequestDelegate next)
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
      context.Response.ContentType = MediaTypeNames.Application.Json;
      context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

      await context.Response.WriteAsync(JsonSerializer.Serialize(new
      {
        context.Response.StatusCode,
        ex.Message
      }));
    }
  }
}