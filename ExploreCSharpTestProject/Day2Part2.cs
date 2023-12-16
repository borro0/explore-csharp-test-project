namespace ExploreCSharpTestProject;
using System.IO;
using Xunit.Sdk;
using System.Reflection;

public class Day2Part2Test
{
    [Fact]
    public void TestPower_SingleSet()
    {
        string[] input = { "Game 1: 1 blue, 1 red, 1 green" };
        Assert.Equal(1, Game.PowerOfMinimumSetOfCubes(input));
    }

    [Fact]
    public void TestPower_MultipleSets()
    {
        string[] input = { "Game 1: 2 blue, 2 red, 2 green; 1 blue, 4 red, 4 green" };
        Assert.Equal(32, Game.PowerOfMinimumSetOfCubes(input));
    }

    [Fact]
    public void TestPower_MultipleSetsNoRed()
    {
        string[] input = { "Game 1: 7 blue, 14 green; 8 blue" };
        Assert.Equal(112, Game.PowerOfMinimumSetOfCubes(input));
    }

    [Fact]
    public void TestMultipleSets()
    {
        string[] input = { "Game 1: 7 blue, 10 red, 12 green; 15 blue" };
        Assert.Equal(0, Game.CalculateValidGameSum(input));
    }

    [Fact]
    public void TestTwoGames()
    {
        string[] input = {
            "Game 1: 7 blue, 10 red, 12 green; 15 blue",
            "Game 2: 1 blue"
        };
        Assert.Equal(2, Game.CalculateValidGameSum(input));
    }

    [Fact]
    public void TestThreeGames()
    {
        string[] input = {
            "Game 1: 7 blue, 10 red, 12 green; 15 blue",
            "Game 2: 1 blue",
            "Game 3: 10 blue; 10 green; 10 red, 10 blue; 10 green, 10 blue, 10 red"
        };
        Assert.Equal(5, Game.CalculateValidGameSum(input));
    }

    [Fact]
    public void TestCompleteSolutionPower()
    {
        string input_file_path = @"C:\Users\bblokland\explore-csharp-test-project\ExploreCSharpTestProject\advent-of-code-day-2-input.txt";
        string[] input = File.ReadAllLines(input_file_path);
        int result = Game.PowerOfMinimumSetOfCubes(input);
        Console.WriteLine($"result: {result}");
    }
}