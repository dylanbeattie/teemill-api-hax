using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using TeemillApiHax.Models;

namespace TeemillApiHax.Controllers;

public class TeemillApiClient {
	private readonly string projectName;
	private readonly string secretKey;
	private HttpClient http = new();

	public TeemillApiClient(string projectName, string secretKey) {
		this.projectName = projectName;
		this.secretKey = secretKey;
		http.DefaultRequestHeaders.Add("Authorization", secretKey);
	}

	public IEnumerable<GfnCatalogProduct> ListGfnCatalogProducts() {
		List<GfnCatalogProduct> products = new();
		int? pageToken = 1;
		while (pageToken.HasValue) {
			var url = $"https://api.podos.io/v1/gfn/catalog/products?project={projectName}&pageToken={pageToken}";
			var response = http.GetFromJsonAsync<GfnCatalogProductList>(url).Result;
			if (response == null) break;
			foreach (var product in response.Products) yield return product;
			products.AddRange(response.Products);
			pageToken = response.NextPageToken;
		}
	}

	static readonly MediaTypeHeaderValue mediaType = new MediaTypeHeaderValue("application/json");

	public async Task<string> CreateProduct(Product product) {
		var url = $"https://api.podos.io/v1/catalog/products?project={projectName}";
		var json = JsonSerializer.Serialize(product, JsonSerializerOptions.Web);
		Console.WriteLine(json);
		Console.ReadKey();
		var content = new StringContent(json, Encoding.UTF8, mediaType);
		var response = await http.PostAsync(url, content);
		return await response.Content.ReadAsStringAsync();
	}
}
