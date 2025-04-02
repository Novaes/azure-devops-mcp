namespace azure_devops_mcp_client.src.config
{
    internal class RootConfig
    {
        public List<ServerConfig> Servers { get; set; }
    }

    internal class ServerConfig
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Command { get; set; }
        public string[] Args { get; set; }
     }

}
