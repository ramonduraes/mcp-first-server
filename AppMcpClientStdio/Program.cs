using ModelContextProtocol.Client;

Console.WriteLine("Initializing MCP Stdio Client...");

var transportOptions = new StdioClientTransport(new StdioClientTransportOptions
{
    Name = "MCP Stdio Client",
    Command = "dotnet",
    Arguments = new[] { "run", "--project", @"..\AppMcpServer" }
});

// Create the MCP client with the specified transport
var mcpClient = await McpClientFactory.CreateAsync(transportOptions);
// Retrieve the list of available tools
var availableTools = await mcpClient.ListToolsAsync();


// Display available tools
Console.WriteLine("Available Tools:");
foreach (var tool in availableTools)
{
    Console.WriteLine($"Name: {tool.Name}");
    Console.WriteLine($"Description: {tool.Description}");
    Console.WriteLine($"Schema: {tool.JsonSchema}");
    Console.WriteLine(new string('-', 30));  
}





