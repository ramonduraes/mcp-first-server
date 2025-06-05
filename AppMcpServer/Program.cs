Console.WriteLine("Initializing Streamable HTTP MCP Server...");
Console.WriteLine("http://localhost:5000/mcp");

var builder = WebApplication.CreateBuilder(args);

// 1. Register the MCP server in the service container
builder.Services.AddMcpServer()
    .WithStdioServerTransport() // Use Stdio transport for the MCP server
    .WithHttpTransport()           // Use HTTP transport for the MCP server
    .WithToolsFromAssembly();      // Automatically discoer and register MCP tools from this assembly

builder.WebHost.UseUrls("http://localhost:5000");

var app = builder.Build();

// 2. Map root route to a welcome message
app.MapGet("/", () => "Welcome to .NET MCP Server !!");
// 3. Map the "/mcp" endpoint to the MCP server
app.MapMcp("/mcp");
// 4. Start the server
app.Run();

Console.WriteLine("Finish MCP Server");
