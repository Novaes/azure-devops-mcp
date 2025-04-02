using ModelContextProtocol.Server;
using System.ComponentModel;

namespace azure_devops_mcp_server.src.tools
{

    /// <summary>
    /// This tool is used for validation purposes. It echoes the message back to the client.
    /// </summary>
    [McpServerToolType]
    public static class EchoTool
    {
        [McpServerTool, Description("Echoes the message back to the client.")]
        public static string Echo(string message) => $"hello {message}";
    }
}
