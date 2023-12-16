namespace ExploreCSharpTestProject;
using System.IO;
using Xunit.Sdk;
using System.Reflection;

public class Game
{
    public static readonly string[] Colors = { "blue", "red", "green" };
    public static int CalculateValidGameSum(string[] lines)
    {
        int result = 0;
        foreach (string line in lines)
        {
            Game game = new Game(line);
            if (game.IsValid)
            {
                result += game.Id;
            }
        }
        return result;
    }
    public static int PowerOfMinimumSetOfCubes(string[] lines)
    {
        int result = 0;
        foreach (string line in lines)
        {
            Game game = new Game(line);
            result += game.PowerMinimumSetOfCubes;
        }
        return result;
    }

    public int Id { get; }
    public int PowerMinimumSetOfCubes { get; } = 0;
    public bool IsValid { get; } = true;
    public Game(string gameDescription)
    {
        string[] parts = gameDescription.Split(": ");
        Id = ParseId(parts[0]);
        string[] cube_strings = parts[1].Split("; ");
        Dictionary<string, int> minimalCubeMap = new Dictionary<string, int>();
        foreach (string color in Game.Colors)
        {
            minimalCubeMap[color] = 0;
        }
        foreach (string cube_string in cube_strings)
        {
            Dictionary<string, int> cubeMap = ParseCubeString(cube_string);
            if (cubeMap["blue"] > 14 || cubeMap["red"] > 12 || cubeMap["green"] > 13)
            {
                IsValid = false;
            }
            foreach (string color in Game.Colors)
            {
                if (minimalCubeMap[color] < cubeMap[color])
                {
                    minimalCubeMap[color] = cubeMap[color];
                }
            }
        }
        PowerMinimumSetOfCubes = 1;
        foreach (string color in Game.Colors)
        {
            if (minimalCubeMap[color] != 0) {
                PowerMinimumSetOfCubes *= minimalCubeMap[color];
            }
        }
    }

    private int ParseId(string input)
    {
        // Game 1
        string[] parts = input.Split(" ");
        int result = int.Parse(parts[1]);
        return result;
    }

    private Dictionary<string, int> ParseCubeString(string input)
    {
        // 7 blue, 13 red, 12 green
        string[] color_parts = input.Split(", ");
        Dictionary<string, int> cubeMap = new Dictionary<string, int>();
        foreach (string color in Game.Colors)
        {
            cubeMap[color] = 0;
        }
        foreach (string color_part in color_parts)
        {
            string[] parts = color_part.Split(" ");
            cubeMap[parts[1]] = int.Parse(parts[0]);
        }
        return cubeMap;
    }
}

public class Day2Test
{
    [Fact]
    public void TestParseSimpleGame()
    {
        Game game = new Game("Game 1: 7 blue");
        Assert.Equal(1, game.Id);
    }

    [Fact]
    public void TestSingleSetSingleColorGame()
    {
        string[] input = { "Game 1: 7 blue" };
        Assert.Equal(1, Game.CalculateValidGameSum(input));
    }

    [Fact]
    public void TestSingleSetMultipleColorsTooMuchRedGame()
    {
        string[] input = { "Game 1: 7 blue, 13 red" };
        Assert.Equal(0, Game.CalculateValidGameSum(input));
    }

    [Fact]
    public void TestSingleSetMultipleColorsTooMuchGreenGame()
    {
        string[] input = { "Game 1: 7 blue, 10 red, 14 green" };
        Assert.Equal(0, Game.CalculateValidGameSum(input));
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
    public void TestCompleteSolutionValidGameSum()
    {
        string input_file_path = @"C:\Users\bblokland\explore-csharp-test-project\ExploreCSharpTestProject\advent-of-code-day-2-input.txt";
        string[] input = File.ReadAllLines(input_file_path);
        int result = Game.CalculateValidGameSum(input);
        Console.WriteLine($"result: {result}");
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