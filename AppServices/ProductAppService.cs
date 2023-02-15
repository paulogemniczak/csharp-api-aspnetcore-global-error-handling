using csharp_api_aspnetcore_global_error_handling.Dto;
using csharp_api_aspnetcore_global_error_handling.Exceptions;

namespace csharp_api_aspnetcore_global_error_handling.AppService
{
	public class ProductAppService
	{
		public IEnumerable<ProductDto> GetProducts() => 
			new List<ProductDto>
			{
				new ProductDto() {ProductId = 1, ProductName = "Rice", ProductPrice = 30},
				new ProductDto() {ProductId = 2, ProductName = "Apple", ProductPrice = 5},
				new ProductDto() {ProductId = 3, ProductName = "Banana", ProductPrice = 4},
				new ProductDto() {ProductId = 4, ProductName = "Suggar", ProductPrice = 15},
				new ProductDto() {ProductId = 5, ProductName = "Salt", ProductPrice = 10}
			};

		public IEnumerable<ProductDto> GetProductsWithException() => 
			throw new Exception("Internal server error");

		public IEnumerable<ProductDto> GetProductsWithCustomException() =>
			throw new MyCustomException("Custom exception");
	}
}
