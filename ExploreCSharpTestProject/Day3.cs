namespace ExploreCSharpTestProject;
using System.IO;
using Xunit.Sdk;
using System.Reflection;

public class EngineNumbers
{
    private string[] input;
    public EngineNumbers(string[] string_input)
    {
        input = string_input;
    }

    public int CalculateNumber()
    {
        for (int x = 0; x < input.Length; x++) {
            int start_number = -1;
            for (int y = 0; y < input[x].Length; y++) {
                if (Char.IsDigit(input[x][y])) {
                    
                }
            }
        }
        return 0;
    }
}

public class Day3Test
{
    [Fact]
    public void Test_SingleLine()
    {
        string[] input = { "467*.." };
        EngineNumbers engine = new EngineNumbers(input);
        Assert.Equal(467, engine.CalculateNumber());
    }

}