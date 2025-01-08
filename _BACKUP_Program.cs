// using System.Net.Http.Headers;
// using System.Text;
// using Microsoft.Extensions.Configuration;

// var config = new ConfigurationBuilder()
// 	.UseDotEnvFile()
// 	.AddEnvironmentVariables()
// 	.Build();

// var client = new HttpClient();
// client.DefaultRequestHeaders.Add("Authorization", config["TeemillSecretApiKey"]);
// for (var pageToken = 0; pageToken < 10; pageToken++) {
// 	var url = $"https://api.podos.io/v1/gfn/catalog/products?project={config["TeemillProjectName"]}&pageSize=100&pageToken={pageToken}";
// 	try {
// 		var response = await client.GetStringAsync(url);
// 		File.WriteAllText($"json/responses/gfn_catalog_products_{pageToken}.json", response);
// 		Console.WriteLine(response);
// 	}
// 	catch (Exception ex) {
// 		Console.WriteLine(pageToken + ": " + ex.Message);
// 	}
// }
// return;



// // var url = $"https://api.podos.io/v1/catalog/products?project={config["TeemillProjectName"]}";

// // var requestJson = File.ReadAllText("sample-tshirt.json");
// // var content = new StringContent(requestJson, Encoding.UTF8, new MediaTypeHeaderValue("application/json"));
// // var response = await client.PostAsync(url, content);
// // Console.WriteLine(await response.Content.ReadAsStringAsync());


// // var client = new HttpClient();
// // var request = new HttpRequestMessage {
// // 	Method = HttpMethod.Post,
// // 	RequestUri = new Uri($"https://api.podos.io/v1/catalog/products?project={config["TeemillProjectName"]}"),
// // 	Headers = {
// // 		{ "Accept", "application/json" },
// // 		{ "Authorization", config["TeemillSecretApiKey"] },
// // 	},
// // 	Content = new StringContent(File.ReadAllText("sample-tshirt.json")) {
// // 		Headers = {
// // 			ContentType = new MediaTypeHeaderValue("application/json")
// // 		}
// // 	}
// // };
// // using (var response = await client.SendAsync(request)) {
// // 	var body = await response.Content.ReadAsStringAsync();
// // 	Console.WriteLine(body);
// // }