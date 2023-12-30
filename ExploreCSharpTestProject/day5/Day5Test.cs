namespace ExploreCSharpTestProject;

public class Day5Test
{
    [Fact]
    public void Test_SeedToSoilMap()
    {
        string[] input = {
            "seeds: 79 55",
            "",
            "seed-to-soil map:",
            "50 98 2",
            "52 50 48",
        };
        SeedMapper seedMapper = new SeedMapper(input);
        long result = seedMapper.GetLowestMappedSeedNormal();
        Assert.Equal(57, result);
    }

    [Fact]
    public void Test_SeedToSoilMapNotInMap()
    {
        string[] input = {
            "seeds: 79 55 14 13",
            "",
            "seed-to-soil map:",
            "50 98 2",
            "52 50 48",
        };
        SeedMapper seedMapper = new SeedMapper(input);
        long result = seedMapper.GetLowestMappedSeedNormal();
        Assert.Equal(13, result);
    }

    [Fact]
    public void Test_SeedToSoilMapBiggerList()
    {
        string[] input = {
            "seeds: 79 55",
            "",
            "seed-to-soil map:",
            "1 1 1",
            "50 98 2",
            "52 50 48",
        };
        SeedMapper seedMapper = new SeedMapper(input);
        long result = seedMapper.GetLowestMappedSeedNormal();
        Assert.Equal(57, result);
    }

    [Fact]
    public void Test_MultipleMaps()
    {
        string[] input = {
            "seeds: 79 14 55 13",
            "",
            "seed-to-soil map:",
            "50 98 2",
            "52 50 48",
            "",
            "soil-to-fertilizer map:",
            "0 15 37",
            "37 52 2",
            "39 0 15",
        };
        SeedMapper seedMapper = new SeedMapper(input);
        long result = seedMapper.GetLowestMappedSeedNormal();
        Assert.Equal(52, result);
    }


    [Fact]
    public void Test_CompleteSolution()
    {
        string input_file_path = @"C:\Users\bblokland\explore-csharp-test-project\ExploreCSharpTestProject\day5\input.txt";
        string[] input = File.ReadAllLines(input_file_path);
        SeedMapper seedMapper = new SeedMapper(input);
        long result = seedMapper.GetLowestMappedSeedNormal();
        Console.WriteLine($"result: {result}");
    }
}