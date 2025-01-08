using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TeemillApiHax.Models;

namespace TeemillApiHax.Controllers;

public class HomeController(TeemillApiClient teemillApiClient) : Controller {
	private TeemillApiClient teemill = teemillApiClient;

	public IActionResult Index() {
		var products = teemill.ListGfnCatalogProducts();
		return View(products.ToList());
	}

	public IActionResult Privacy() {
		return View();
	}

	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error() {
		return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
	}
}
