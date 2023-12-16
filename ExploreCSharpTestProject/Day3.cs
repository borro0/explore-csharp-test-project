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
        for (int y = 0; y < input.Length; y++) {
            lineLength = input[y].Length;
            for (int x = 0; x < lineLength; x++) {
                ProcessCharacter(x, y);                
            }
        }
        return 0;
    }
    private int lineLength = 0;

    private bool numberActive = false;
    private bool isNumberWithSymbol = false;
    private int currentNumber = 0;

    private void ProcessCharacter(int x, int y) {
        char character = input[x][y];
        if (Char.IsDigit(character)) {
            int value = int.Parse(character.ToString());
            if (numberActive) {
                currentNumber = currentNumber * 10 + value;
            } else {
                numberActive = true;
                currentNumber = value;
            }
            if (!isNumberWithSymbol) {
                isNumberWithSymbol = CheckForSymbolNeighbour(x, y);
            }
        } else {
            numberActive = false;
            isNumberWithSymbol = false;
            currentNumber = 0;
        }
    }

    private bool CheckForSymbolNeighbour(int x, int y) {
        int nextIndex = x + 1;
        if (nextIndex < lineLength) {
            char nextChar = input[nextIndex][y];
        }
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