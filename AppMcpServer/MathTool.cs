using ModelContextProtocol.Server;
using System.ComponentModel;

[McpServerToolType]
public class MathTools
{
    [McpServerTool(Name = "Multiply"), Description("Multiplies two integers and returns the result. Example: 3 * 4 = 12")]
    public int Multiply(int a, int b) => a * b;

    [McpServerTool(Name = "Divide"), Description("Divides two integers and returns the result as a decimal. Example: 10 / 4 = 2.5")]
    public double Divide(int a, int b) => (double)a / b;

    [McpServerTool(Name = "Add"), Description("Adds two integers and returns the result. Example: 5 + 2 = 7")]
    public int Add(int a, int b) => a + b;

    [McpServerTool(Name = "Subtract"), Description("Subtracts the second integer from the first and returns the result. Example: 9 - 3 = 6")]
    public int Subtract(int a, int b) => a - b;
}
