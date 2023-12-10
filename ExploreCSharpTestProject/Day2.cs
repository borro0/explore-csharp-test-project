namespace ExploreCSharpTestProject;
using System.IO;
using Xunit.Sdk;
using System.Reflection;

public class Game
{
    public int Id { get; }
    public Game(string gameDescription)
    {
        string[] parts = gameDescription.Split(":");
        Id = ParseId(parts[0]);
    }

    private int ParseId(string input)
    {
        string[] parts = input.Split(" ");
        int result = int.Parse(parts[1]);
        return result;
    }
}

public class Day2Test
{
    [Fact]
    public void TestParseSimpleGame()
    {
        Game game = new Game("Game 1: 7 blue");
        // Assert.Equal(7, game.AmountOfBlue);
        Assert.Equal(1, game.Id);
    }
}