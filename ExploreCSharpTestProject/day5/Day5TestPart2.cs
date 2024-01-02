namespace ExploreCSharpTestProject;

public class Day5TestPart2
{
    [Fact]
    public void Test_InputRangeShouldRemainEqualWhenOutsideMapFunction()
    {
        Range range = new Range(0, 10);
        List<MapFunction> map_functions = new List<MapFunction>();
        map_functions.Add(new MapFunction(10, 20, 10));
        List<Range> result = SeedMapper.MapRange(range, map_functions);
        Assert.Equal(new List<Range>{ new Range(0, 10) }, result);
    }
    
    [Fact]
    public void Test_InputRangeShouldBeMappedWhenInsideMapFunction()
    {
        Range range = new Range(10, 10);
        List<MapFunction> map_functions = new List<MapFunction>();
        map_functions.Add(new MapFunction(50, 0, 20));
        List<Range> result = SeedMapper.MapRange(range, map_functions);
        Assert.Equal(new List<Range> { new Range(60, 10) }, result);
    }

    //[Fact]
    //public void Test_RangeStyle()
    //{
    //    string input_file_path = @"C:\Users\bblokland\explore-csharp-test-project\ExploreCSharpTestProject\day5\input-test-part-2.txt";
    //    string[] input = File.ReadAllLines(input_file_path);
    //    SeedMapper seedMapper = new SeedMapper(input);
    //    long result = seedMapper.GetLowestMappedSeedRangeStyle();
    //    Assert.Equal(46, result);
    //}


    //[Fact]
    //public void Test_CompleteSolution()
    //{
    //    string input_file_path = @"C:\Users\bblokland\explore-csharp-test-project\ExploreCSharpTestProject\day5\input.txt";
    //    string[] input = File.ReadAllLines(input_file_path);
    //    SeedMapper seedMapper = new SeedMapper(input);
    //    long result = seedMapper.GetLowestMappedSeedRangeStyle();
    //    Console.WriteLine($"result: {result}");
    //}
}