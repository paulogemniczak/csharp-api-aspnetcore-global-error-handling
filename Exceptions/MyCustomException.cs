namespace csharp_api_aspnetcore_global_error_handling.Exceptions
{
	[Serializable]
	public class MyCustomException : Exception
	{
		public MyCustomException()
		{
		}

		public MyCustomException(string message) : base(message)
		{
		}

		public MyCustomException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
