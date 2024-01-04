namespace ExploreCSharpTestProject;

public class Day5TestPart2
{
    [Fact]
    public void Test_InputRangeShouldRemainEqualWhenOutsideMapFunction()
    {
        List<Range> ranges = [new Range(0, 10)];
        List<MapFunction> mapFunctions = [new MapFunction(10, 20, 10)];
        RangeTransformer rangeTransformer = new RangeTransformer(mapFunctions);
        List<Range> result = rangeTransformer.Transform(ranges);
        Assert.Equal(new List<Range> { new Range(0, 10) }, result);
    }

    [Fact]
    public void Test_InputRangeShouldBeMappedWhenInsideMapFunction()
    {
        List<Range> ranges = [new Range(10, 10)];
        List<MapFunction> mapFunctions = [new MapFunction(50, 0, 20)];
        RangeTransformer rangeTransformer = new RangeTransformer(mapFunctions);
        List<Range> result = rangeTransformer.Transform(ranges);
        Assert.Equal(new List<Range> { new Range(60, 10) }, result);
    }

    [Fact]
    public void Test_InputRangeShouldBeSplitWhenPartlyOverlapsWithBeginOfMapFunction()
    {
        List<Range> ranges = [new Range(10, 10)];
        List<MapFunction> mapFunctions = [new MapFunction(50, 15, 20)];
        RangeTransformer rangeTransformer = new RangeTransformer(mapFunctions);
        List<Range> result = rangeTransformer.Transform(ranges);
        Assert.Equivalent(new List<Range> { new Range(10, 5), new Range(50, 5) }, result);
    }

    [Fact]
    public void Test_InputRangeShouldBeSplitWhenPartlyOverlapsWithEndOfMapFunction()
    {
        List<Range> ranges = [new Range(15, 10)];
        List<MapFunction> mapFunctions = [new MapFunction(50, 0, 20)];
        RangeTransformer rangeTransformer = new RangeTransformer(mapFunctions);
        List<Range> result = rangeTransformer.Transform(ranges);
        Assert.Equivalent(new List<Range> { new Range(20, 5), new Range(65, 5) }, result);
    }

    [Fact]
    public void Test_InputRangeShouldBeSplitWhenCompletelyOverlapsMapFunction()
    {
        List<Range> ranges = [new Range(0, 20)];
        List<MapFunction> mapFunctions = [new MapFunction(50, 5, 10)];
        RangeTransformer rangeTransformer = new RangeTransformer(mapFunctions);
        List<Range> result = rangeTransformer.Transform(ranges);
        Assert.Equivalent(new List<Range> { new Range(0, 5), new Range(50, 10), new Range(15, 5) }, result);
    }

    [Fact]
    public void Test_TransformSimpleMultipleRangesAndMapFunctions()
    {
        List<Range> ranges = [new Range(79, 14), new Range(55, 13)];
        List<MapFunction> mapFunctions = [new MapFunction(50, 98, 2), new MapFunction(52, 50, 48)];
        RangeTransformer rangeTransformer = new RangeTransformer(mapFunctions);
        List<Range> result = rangeTransformer.Transform(ranges);
        Assert.Equivalent(new List<Range> { new Range(81, 14), new Range(57, 13) }, result);
    }

    [Fact]
    public void Test_TransformDifficultMultipleRangesAndMapFunctions()
    {
        List<Range> ranges = [new Range(81, 14), new Range(57, 13)];
        List<MapFunction> mapFunctions = [
            new MapFunction(49, 53, 8),
            new MapFunction(0, 11, 42),
            new MapFunction(42, 0, 7),
            new MapFunction(57, 7, 4)
        ];
        RangeTransformer rangeTransformer = new RangeTransformer(mapFunctions);
        List<Range> result = rangeTransformer.Transform(ranges);
        Assert.Equivalent(new List<Range> { new Range(81, 14), new Range(61, 9), new Range(53, 4) }, result);
    }

    [Fact]
    public void Test_SingleMap()
    {
        string[] input = {
            "seeds: 79 14 55 13",
            "",
            "seed-to-soil map:",
            "50 98 2",
            "52 50 48",
        };
        SeedMapper seedMapper = new SeedMapper(input);
        long result = seedMapper.GetLowestMappedSeedRangeStyle();
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
            "", // (81, 14) (57, 13)
            "fertilizer-to-water map:",
            "49 53 8",
            "0 11 42",
            "42 0 7",
            "57 7 4",
            // (81, 14) (61, 9) (53, 4)
        };
        SeedMapper seedMapper = new SeedMapper(input);
        long result = seedMapper.GetLowestMappedSeedRangeStyle();
        Assert.Equal(53, result);
    }

    [Fact]
    public void Test_BigMapSmallNumbers()
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