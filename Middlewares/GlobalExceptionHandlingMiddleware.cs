using csharp_api_aspnetcore_global_error_handling.Contracts;
using csharp_api_aspnetcore_global_error_handling.Exceptions;

namespace csharp_api_aspnetcore_global_error_handling.Middlewares
{
	public class GlobalExceptionHandlingMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;

		public GlobalExceptionHandlingMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlingMiddleware> logger)
		{
			_next = next;
			_logger = logger;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (MyCustomException ex)
			{
				_logger.LogError(ex, ex.Message);
				await HandleExceptionAsync(context, ex, StatusCodes.Status400BadRequest); // 400 i picked randomly just to test
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				await HandleExceptionAsync(context, ex, StatusCodes.Status500InternalServerError);
			}
		}

		private async Task HandleExceptionAsync(HttpContext context, Exception exception, int statusCode)
		{
			context.Response.ContentType = "application/json";
			context.Response.StatusCode = statusCode;
			var message = exception switch
			{
				MyCustomException => "My custom violation error from the custom middleware",
				_ => "Internal Server Error from the custom middleware."
			};
			await context.Response.WriteAsync(new ErrorDetails()
			{
				StatusCode = context.Response.StatusCode,
				Message = message
			}.ToString());
		}
	}
}
