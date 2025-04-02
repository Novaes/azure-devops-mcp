using azure_devops_mcp_client.src.config;
using System.Text.Json;

namespace azure_devops_mcp_client.src.core
{
    internal class ConfigurationService
    {
        public static async Task<RootConfig> ReadConfigurationAsync(string filePath)
        {
            using var stream = File.OpenRead(filePath);
            return await JsonSerializer.DeserializeAsync<RootConfig>(stream);
        }
    }
}
