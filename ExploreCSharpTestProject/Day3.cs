namespace ExploreCSharpTestProject;
using System.IO;
using Xunit.Sdk;
using System.Reflection;

public struct Position
{
    public int CharIndex;
    public int LineIndex;

    public Position(int charIndex, int lineIndex)
    {
        CharIndex = charIndex;
        LineIndex = lineIndex;
    }
}

public class EngineNumbers
{
    private string[] input;
    public EngineNumbers(string[] string_input)
    {
        input = string_input;
    }

    public int CalculateNumber()
    {
        for (int lineIndex = 0; lineIndex < input.Length; lineIndex++)
        {
            lineLength = input[lineIndex].Length;
            for (int charIndex = 0; charIndex < lineLength; charIndex++)
            {
                ProcessCharacter(charIndex, lineIndex);
            }
        }
        return sum;
    }
    private int lineLength = 0;

    private bool numberActive = false;
    private bool isNumberWithSymbol = false;
    private int currentNumber = 0;
    private int sum = 0;

    private void ProcessCharacter(int charIndex, int lineIndex)
    {
        char character = input[lineIndex][charIndex];
        if (Char.IsDigit(character))
        {
            ProcessDigit(charIndex, lineIndex, character);
        }
        else
        {
            ProcessNonDigit();
        }
    }

    private void ProcessNonDigit()
    {
        if (numberActive)
        {
            CloseNumber();
        }

    }

    private void CloseNumber()
    {
        if (isNumberWithSymbol)
        {
            sum += currentNumber;
        }
        numberActive = false;
        isNumberWithSymbol = false;
        currentNumber = 0;
    }

    private void ProcessDigit(int charIndex, int lineIndex, char character)
    {
        int value = int.Parse(character.ToString());
        if (numberActive)
        {
            currentNumber = currentNumber * 10 + value;
        }
        else
        {
            numberActive = true;
            currentNumber = value;
        }
        if (!isNumberWithSymbol)
        {
            isNumberWithSymbol = CheckForSymbolNeighbor(charIndex, lineIndex);
        }
    }

    private bool CheckForSymbolNeighbor(int charIndex, int lineIndex)
    {
        List<Position> positionsToCheck = new List<Position>();
        positionsToCheck.Add(new Position(charIndex - 1, lineIndex));
        positionsToCheck.Add(new Position(charIndex + 1, lineIndex));
        positionsToCheck.Add(new Position(charIndex - 1, lineIndex + 1));
        positionsToCheck.Add(new Position(charIndex, lineIndex + 1));
        positionsToCheck.Add(new Position(charIndex + 1, lineIndex + 1));
        foreach (Position position in positionsToCheck)
        {
            if (IsPositionValid(position) && IsSymbolAtPosition(position))
            {
                return true;
            }
        }
        return false;
    }

    private bool IsPositionValid(Position position)
    {
        bool validCharIndex = position.CharIndex >= 0 && position.CharIndex < lineLength;
        bool validLineIndex = position.LineIndex >= 0 && position.LineIndex < input.Length;
        return validCharIndex && validLineIndex;
    }

    private bool IsSymbolAtPosition(Position position)
    {
        char nextChar = input[position.LineIndex][position.CharIndex];
        return IsSymbol(nextChar);
    }

    private static bool IsSymbol(char character)
    {
        if (Char.IsDigit(character))
        {
            return false;
        }
        if (character == '.')
        {
            return false;
        }
        return true;
    }
}

public class Day3Test
{
    [Fact]
    public void Test_SingleLineValidNumber()
    {
        string[] input = { "467*.." };
        EngineNumbers engine = new EngineNumbers(input);
        Assert.Equal(467, engine.CalculateNumber());
    }

    [Fact]
    public void Test_SingleLineInvalidNumber()
    {
        string[] input = { "467.*." };
        EngineNumbers engine = new EngineNumbers(input);
        Assert.Equal(0, engine.CalculateNumber());
    }

    [Fact]
    public void Test_SingleLineSymbolAtStart()
    {
        string[] input = { "..*18.." };
        EngineNumbers engine = new EngineNumbers(input);
        Assert.Equal(18, engine.CalculateNumber());
    }

    [Fact]
    public void Test_SingleLineMultipleNumbers()
    {
        string[] input = { "..*18..345.45).1.12!" };
        EngineNumbers engine = new EngineNumbers(input);
        Assert.Equal(18 + 45 + 12, engine.CalculateNumber());
    }

    [Fact]
    public void Test_MultipleLines_LineBelowRightBottom()
    {
        string[] input = {
            ".3..",
            "..*."
        };
        EngineNumbers engine = new EngineNumbers(input);
        Assert.Equal(3, engine.CalculateNumber());
    }

    [Fact]
    public void Test_MultipleLines_LineBelowMiddle()
    {
        string[] input = {
            ".3..",
            ".*.."
        };
        EngineNumbers engine = new EngineNumbers(input);
        Assert.Equal(3, engine.CalculateNumber());
    }

    [Fact]
    public void Test_MultipleLines_LineBelowLeftBottom()
    {
        string[] input = {
            ".3..",
            "*..."
        };
        EngineNumbers engine = new EngineNumbers(input);
        Assert.Equal(3, engine.CalculateNumber());
    }

}