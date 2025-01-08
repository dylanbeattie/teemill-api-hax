
using Microsoft.Extensions.Configuration;

public static class ConfigurationBuilderExtensions {
	public static ConfigurationBuilder UseDotEnvFile(this ConfigurationBuilder builder, string filename = ".env") {
		if (!File.Exists(filename)) return builder;
		foreach (var setting in File.ReadAllLines(filename)
			.Select(line => line.Split("="))
			.Where(parts => parts.Length == 2)) {
			Environment.SetEnvironmentVariable(setting[0], setting[1]);
		}
		return builder;
	}
}