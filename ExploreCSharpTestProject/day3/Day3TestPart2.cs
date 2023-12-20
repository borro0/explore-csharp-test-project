namespace ExploreCSharpTestProject;
using System.IO;
using Xunit.Sdk;
using System.Reflection;

public class Day3TestPart2
{
    [Fact]
    public void Test_SingleLineValidNumber()
    {
        string[] input = { ".10*10." };
        EngineNumbers engine = new EngineNumbers(input);
        Assert.Equal(100, engine.SumOfGearRatios());
    }

    [Fact]
    public void Test_SingleLineMultipleValidNumbers()
    {
        string[] input = { ".10*10...2*55" };
        EngineNumbers engine = new EngineNumbers(input);
        Assert.Equal(100+110, engine.SumOfGearRatios());
    }

    [Fact]
    public void Test_MultipleLinesMultipleValidNumbers()
    {
        string[] input = { 
            "48..........",
            "...491.842..",
            "...*...*....",
            "363.....961.",
        };
        EngineNumbers engine = new EngineNumbers(input);
        Assert.Equal(363*491+842*961, engine.SumOfGearRatios());
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
        Assert.Equal(501 * 948 + 491 * 363 + 842 * 961 + 508 * 223 + 501 * 948, engine.SumOfGearRatios());
    }

    [Fact]
    public void Test_CompleteSolution()
    {
        string input_file_path = @"C:\Users\bblokland\explore-csharp-test-project\ExploreCSharpTestProject\day3\input.txt";
        string[] input = File.ReadAllLines(input_file_path);
        EngineNumbers engine = new EngineNumbers(input);
        int result = engine.SumOfGearRatios();
        Console.WriteLine($"result: {result}");
    }
}