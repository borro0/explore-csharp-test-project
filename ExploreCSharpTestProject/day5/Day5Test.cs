namespace ExploreCSharpTestProject;

public class Day5Test
{
    [Fact]
    public void Test_SeedToSoilMap()
    {
        string[] input = {
            "seeds: 79 14 55 13",
            "",
            "seed-to-soil map:",
            "50 98 2",
            "52 50 48",
        };
        SeedMapper seedMapper = new SeedMapper(input);
        int result = seedMapper.GetLowestMappedSeed();
        Assert.Equal(13, result);
    }
}