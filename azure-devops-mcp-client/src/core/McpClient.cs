using azure_devops_mcp_client.src.config;
using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol.Transport;

namespace azure_devops_mcp_client.src.core
{
    public class McpClient
    {

        public static readonly string mcpFilePath = Path.Combine(AppContext.BaseDirectory, "Properties", "mcp.json");

        public static async Task Main(string[] args)
        {
            //var config = await ConfigurationService.ReadConfigurationAsync(mcpFilePath);
            //Console.WriteLine(config.Servers[0].Name);
            //Console.WriteLine(config.Servers[0].Id);
            //Console.WriteLine(config.Servers[0].Command);
            //Console.WriteLine(config.Servers[0].Args);

            //if (config == null)
            //{
            //    Console.WriteLine($"Failed to read configuration from {mcpFilePath}");
            //    return;
            //}
            //var tasks = config.Servers.Select(StartClientAsync).ToArray();

            var tasks = StartClientAsync(null);
            await Task.WhenAll(tasks);
        }

        private static async Task StartClientAsync(ServerConfig serverConfig)
        {
            var client = await McpClientFactory.CreateAsync(new()
            {
                Id = "everything",
                Name = "Everything",
                TransportType = TransportTypes.StdIo,
                TransportOptions = new()
                {
                    ["command"] = "npx",
                    ["arguments"] = "-y @modelcontextprotocol/server-everything",
                }
            });

            //var client = await McpClientFactory.CreateAsync(new()
            //{
            //    Id = serverConfig.Id,
            //    Name = serverConfig.Name,
            //    TransportType = TransportTypes.StdIo,
            //    TransportOptions = new()
            //    {
            //        ["command"] = serverConfig.Command,
            //        ["arguments"] = string.Join(" ", serverConfig.Args)
            //    }
            //});


            // Print the list of tools available from the server.
            foreach (var tool in await client.ListToolsAsync())
            {
                Console.WriteLine($"{tool.Name} ({tool.Description})");
            }

            // TODO: Claude / GH Copilot integration here VS / VSC
            Console.Write("Enter a message to echo: ");
            string message = Console.ReadLine();
            Console.WriteLine($"{message}");

            // Execute tool (action call)
            var result = await client.CallToolAsync("echo",
                                                   new Dictionary<string, object?>() { ["message"] = "Hello MCP!" },
                                                   CancellationToken.None);

            // echo always returns one and only one text content object
            Console.WriteLine(result.Content.First(c => c.Type == "text").Text);
        }
    }
  }