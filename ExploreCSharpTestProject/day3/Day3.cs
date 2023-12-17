namespace ExploreCSharpTestProject;
using System.IO;
using Xunit.Sdk;
using System.Reflection;

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

    [Fact]
    public void Test_BigExample()
    {
        string[] input = {
            "48.................501....",
            "...491.842.....948*.......",
            "...*...*..................",
            "363.....961...959#.508*223",
            "......=...................",
            ".......39.306...679.%113..",
            "48.................501....",
            "...491.842.....948*.......",
            "...*...*..................",
        };
        EngineNumbers engine = new EngineNumbers(input);
        Assert.Equal(501 + 491 + 842 + 948 + 363 + 961 + 959 + 508 + 223 + 39 + 113 + 501 + 491 + 842 + 948, engine.CalculateNumber());
    }

    [Fact]
    public void Test_CompleteSolution()
    {
        string input_file_path = @"C:\Users\bblokland\explore-csharp-test-project\ExploreCSharpTestProject\day3\input.txt";
        string[] input = File.ReadAllLines(input_file_path);
        EngineNumbers engine = new EngineNumbers(input);
        int result = engine.CalculateNumber();
        Console.WriteLine($"result: {result}");
    }
}