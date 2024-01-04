using System;namespace ExploreCSharpTestProject;public record MapFunction(long DestinationStart, long SourceStart, long Range){    public readonly long SourceEnd = SourceStart + Range;}public record Range(long Start, long Length){    public readonly long End = Start + Length;
    public static Range CreateRangeEndBased(long start, long end)    {        return new Range(start, end - start);    }}public class RangeTransformer{    private List<MapFunction> mapFunctions;

    public RangeTransformer(List<MapFunction> mapFunctions)    {        this.mapFunctions = mapFunctions;    }

    public List<Range> Transform(List<Range> ranges)    {        List<Range> unMappedRanges = ranges;        List<Range> mappedRanges = new List<Range>();        foreach (MapFunction mapFunction in mapFunctions)        {            (unMappedRanges, List<Range> newMappedRanges) = MapRanges(unMappedRanges, mapFunction);            mappedRanges.AddRange(newMappedRanges);        }        mappedRanges.AddRange(unMappedRanges);        return mappedRanges;    }

    private (List<Range>, List<Range>) MapRanges(List<Range> inputRanges, MapFunction mapFunction)    {        List<Range> unMappedRanges = new List<Range>();        List<Range> mappedRanges = new List<Range>();        foreach (Range range in inputRanges)        {            Range currentRange = range;
            if (IsRangeOutsideMapFunction(mapFunction, currentRange))
            {
                unMappedRanges.Add(currentRange);
                continue;
            }
            if (DoesRangeOverlapStartOfMapFunction(mapFunction, currentRange))            {                unMappedRanges.Add(Range.CreateRangeEndBased(currentRange.Start, mapFunction.SourceStart));                currentRange = Range.CreateRangeEndBased(mapFunction.SourceStart, currentRange.End);            }            if (DoesRangeOverlapEndOfMapFunction(mapFunction, currentRange))
            {                unMappedRanges.Add(Range.CreateRangeEndBased(mapFunction.SourceEnd, range.End));                currentRange = Range.CreateRangeEndBased(currentRange.Start, mapFunction.SourceEnd);
            }
            if (IsRangeWithinMapFunction(mapFunction, currentRange))            {                Range mappedRange = MapRangeFullyWithinMapFunction(mapFunction, currentRange);                mappedRanges.Add(mappedRange);            }            else
            {                Assert.Fail("This should not be possible!");            }        }        return (unMappedRanges, mappedRanges);    }

    private static bool DoesRangeOverlapEndOfMapFunction(MapFunction mapFunction, Range range)    {        return range.End > mapFunction.SourceEnd;    }

    private static bool DoesRangeOverlapStartOfMapFunction(MapFunction mapFunction, Range range)    {        return range.Start < mapFunction.SourceStart;    }

    private static Range MapRangeFullyWithinMapFunction(MapFunction mapFunction, Range range)    {        long start = range.Start - mapFunction.SourceStart + mapFunction.DestinationStart;        Range mappedRange = new Range(start, range.Length);        return mappedRange;    }

    private static bool IsRangeOutsideMapFunction(MapFunction mapFunction, Range range)    {        return range.End < mapFunction.SourceStart || mapFunction.SourceEnd < range.Start;    }

    private static bool IsRangeWithinMapFunction(MapFunction mapFunction, Range range)    {        return range.Start >= mapFunction.SourceStart && range.End <= mapFunction.SourceEnd;    }}