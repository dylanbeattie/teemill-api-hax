namespace TeemillApiHax.Models;

public class GfnCatalogProduct {
	public Guid Id { get; set; }
	public string Ref { get; set; } = String.Empty;
	public string Title { get; set; } = String.Empty;
	public string StyleCode { get; set; } = String.Empty;
	public string Material { get; set; } = String.Empty;
	public string Description { get; set; } = String.Empty;
	public string Specifications { get; set; } = String.Empty;
}
public class Product {


	private static string[] sizes = ["XS", "S", "M", "L", "XL", "XXL", "XXXL"];
	public static Product MakeProduct(string gfnProductId, string title, string description, string imageUrl, string[] tags) {
		return new Product {
			GfnProductRef = $"https://api.podos.io/v1/gfn/catalog/products/{gfnProductId}",
			Title = title + " " + gfnProductId,
			Description = description,
			Enabled = true,
			Tags = tags,
			Variants = sizes.Select(size =>
				new Variant {
					Attributes = [
						new VariantAttribute("Size", size),
						new VariantAttribute("Colour", "Black")
					],
					RetailPrice = new RetailPrice { Amount = 25.00m, CurrencyCode = "GBP" },
					Applications = [new Application(imageUrl)]
				}
			).ToList(),
			ApplicationSets = []
		};
	}


	/// <summary>Reference to an existing GF*N product.</summary>
	public required string GfnProductRef { get; set; }

	/// <summary>
	/// Title of the product.
	/// </summary>
	public required string Title { get; set; }

	/// <summary>
	/// Description of the product.
	/// </summary>
	public required string Description { get; set; }

	/// <summary>
	/// Indicates whether the product is enabled (active).
	/// </summary>
	public bool Enabled { get; set; }

	/// <summary>
	/// A list of product variants.
	/// </summary>
	public required List<Variant> Variants { get; set; }

	/// <summary>
	/// A collection of application sets.
	/// </summary>
	public required List<ApplicationSet> ApplicationSets { get; set; }
	public string[] Tags { get; set; } = [];
}

public class Variant {
	/// <summary>
	/// A list of attributes describing the variant (e.g., size, color).
	/// </summary>
	public required List<VariantAttribute> Attributes { get; set; }

	/// <summary>
	/// The retail price object containing amount and currency.
	/// </summary>
	public required RetailPrice RetailPrice { get; set; }

	/// <summary>
	/// A collection of applications (print placements, etc.).
	/// </summary>
	public required List<Application> Applications { get; set; }
}

public class VariantAttribute(string name, string value) {
	/// <summary>
	/// Name of the attribute (e.g., Size, Colour).
	/// </summary>
	public string Name { get; set; } = name;

	/// <summary>
	/// The value of the attribute (e.g., S, Black).
	/// </summary>
	public string Value { get; set; } = value;
}

public class RetailPrice {
	/// <summary>
	/// The numerical amount of the price.
	/// </summary>
	public decimal Amount { get; set; }

	/// <summary>
	/// The currency code (e.g., USD, GBP).
	/// </summary>
	public required string CurrencyCode { get; set; }
}

public class Application(string src) {
	/// <summary>
	/// The printing technology used (e.g., dtg).
	/// </summary>
	public string Technology { get; set; } = "dtg";

	/// <summary>
	/// The placement of the application (front, back, etc.).
	/// </summary>
	public string Placement { get; set; } = "front";

	/// <summary>
	/// A URL or path to the source of the design.
	/// </summary>
	public string Src { get; set; } = src;
}

public class ApplicationSet {
	// The example JSON shows an empty array for applicationSets.
	// You can define properties here if and when you know the schema.
}
