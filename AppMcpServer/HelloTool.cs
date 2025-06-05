using ModelContextProtocol.Server;
using System.ComponentModel;

[McpServerToolType]
public class HelloTool
{
    [McpServerTool(Name = "say"), Description("Return a greeting for the given name. Required: name (string).")]
    public string SayHello([Description("Person's name")] string name)
    {
        var greeting = $"Hello, {name}!";
        return greeting;
    }
}

