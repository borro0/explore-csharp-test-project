namespace ExploreCSharpTestProject;

public class Day5TestPart2
{
    [Fact]
    public void Test_RangeStyle()
    {
        string input_file_path = @"C:\Users\bblokland\explore-csharp-test-project\ExploreCSharpTestProject\day5\input-test-part-2.txt";
        string[] input = File.ReadAllLines(input_file_path);
        SeedMapper seedMapper = new SeedMapper(input);
        long result = seedMapper.GetLowestMappedSeedRangeStyle();
        Assert.Equal(46, result);
    }


    [Fact]
    public void Test_CompleteSolution()
    {
        string input_file_path = @"C:\Users\bblokland\explore-csharp-test-project\ExploreCSharpTestProject\day5\input.txt";
        string[] input = File.ReadAllLines(input_file_path);
        SeedMapper seedMapper = new SeedMapper(input);
        long result = seedMapper.GetLowestMappedSeedRangeStyle();
        Console.WriteLine($"result: {result}");
    }
}