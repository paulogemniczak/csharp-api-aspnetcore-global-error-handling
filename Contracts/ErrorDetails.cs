using System.Text.Json;

namespace csharp_api_aspnetcore_global_error_handling.Contracts
{
	public class ErrorDetails
	{
		public int StatusCode { get; set; }
		public string Message { get; set; } = string.Empty;
		public override string ToString()
		{
			return JsonSerializer.Serialize(this);
		}
	}
}
