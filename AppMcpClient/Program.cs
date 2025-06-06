using ModelContextProtocol.Client;

Console.WriteLine("Initializing MCP Client...");

var transportOptions = new SseClientTransport(new SseClientTransportOptions
{
    
    Name = "MCP Client",
    Endpoint = new Uri("http://localhost:5000/mcp")
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

// Find the "say" tool
var sayTool = availableTools
    .FirstOrDefault(t => string.Equals(t.Name, "say", StringComparison.OrdinalIgnoreCase)) ??
     throw new InvalidOperationException("The 'say' tool is not available.");

// Prepare parameters for the "say" tool
var parameters = new Dictionary<string, object?> { { "name", "ramon" } };

// Call the "say" tool with the parameters
var response = await mcpClient.CallToolAsync(sayTool.Name, parameters);

// Process the response
var result = response.Content?.FirstOrDefault()?.Text ?? "No return";
Console.WriteLine($"Tool response: {result}");





