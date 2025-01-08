namespace TeemillApiHax.Models;

public class GfnCatalogProductList {
	public List<GfnCatalogProduct> Products { get; set; } = new();
	public int? NextPageToken { get; set; }
}
