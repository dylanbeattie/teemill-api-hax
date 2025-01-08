using TeemillApiHax.Controllers;
using TeemillApiHax.Models;

var config = new ConfigurationBuilder()
	.UseDotEnvFile()
	.AddEnvironmentVariables()
	.Build();


var teemillApiClient = new TeemillApiClient(config["TeemillProjectName"], config["TeemillSecretApiKey"]);
foreach (var gfnProductId in new[] {
"c623cbf7-6cd3-11ed-a9b4-4201c0a8a0e3",
"c623c9b2-6cd3-11ed-a9b4-4201c0a8a0e3",
"cb1340a5-6cd3-11ed-a9b4-4201c0a8a0e3",
"cb1348fc-6cd3-11ed-a9b4-4201c0a8a0e3",
"ccc1b345-6cd3-11ed-a9b4-4201c0a8a0e3",
"ccc1dccb-6cd3-11ed-a9b4-4201c0a8a0e3",
"493ed150-6cd4-11ed-a9b4-4201c0a8a0e3",
"9a29fdac-d0fc-4a1b-97f8-35c966734a88" }) {
	var product = Product.MakeProduct(gfnProductId, "An Awesome Product", "this product is totally awesome",
	"https://www.dropbox.com/scl/fi/vdx3q8nrm11iy9hpvf95x/totally-awesome-example-tshirt-design.png?rlkey=ds4lz4qvbr4zztbv6w1g42jvr&dl=1",
	["awesome", "rockstar", "merchandise", "halibut"]);
	var response = await teemillApiClient.CreateProduct(product);
	Console.WriteLine(response);

}


//var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddControllersWithViews();
// builder.Services.AddSingleton(teemillApiClient);

// var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (!app.Environment.IsDevelopment()) {
// 	app.UseExceptionHandler("/Home/Error");
// 	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
// 	app.UseHsts();
// }

// app.UseHttpsRedirection();
// app.UseRouting();

// app.UseAuthorization();

// app.MapStaticAssets();

// app.MapControllerRoute(
// 	name: "default",
// 	pattern: "{controller=Home}/{action=Index}/{id?}")
// 	.WithStaticAssets();


// app.Run();