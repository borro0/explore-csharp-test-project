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


    // [Fact]
    // public void Test_BigExample()
    // {
    //     string[] input = {
    //         "48.................501....",
    //         "...491.842.....948*.......",
    //         "...*...*..................",
    //         "363.....961...959#.508*223",
    //         "......=...................",
    //         ".......39.306...679.%113..",
    //         "48.................501....",
    //         "...491.842.....948*.......",
    //         "...*...*..................",
    //     };
    //     EngineNumbers engine = new EngineNumbers(input);
    //     Assert.Equal(501 + 491 + 842 + 948 + 363 + 961 + 959 + 508 + 223 + 39 + 113 + 501 + 491 + 842 + 948, engine.CalculateNumber());
    // }

    // [Fact]
    // public void Test_CompleteSolution()
    // {
    //     string input_file_path = @"C:\Users\bblokland\explore-csharp-test-project\ExploreCSharpTestProject\day3\input.txt";
    //     string[] input = File.ReadAllLines(input_file_path);
    //     EngineNumbers engine = new EngineNumbers(input);
    //     int result = engine.CalculateNumber();
    //     Console.WriteLine($"result: {result}");
    // }
}