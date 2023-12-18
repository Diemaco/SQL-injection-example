using RestSharp;

namespace Web.Data;

public class ProductService
{
    private readonly RestClient _client = new("http://localhost:8080");

    public Task<Product[]> GetProducts()
    {
	    var request = new RestRequest("/product");

		return _client.GetAsync<Product[]>(request)!;
    }

	public Task<Product[]> SearchProducts(string name)
    {
	    var request = new RestRequest("/product/search_unsafe")
		   .AddParameter("name", name);

		return _client.GetAsync<Product[]>(request)!;
	}
}