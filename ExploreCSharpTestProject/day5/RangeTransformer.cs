using System;

namespace ExploreCSharpTestProject;

public record MapFunction(long DestinationStart, long SourceStart, long Range)
{
    public readonly long SourceEnd = SourceStart + Range;
}

public record Range(long Start, long Length)
{
    public readonly long End = Start + Length;
}

public class RangeTransformer
{
    private List<MapFunction> mapFunctions;

    public RangeTransformer(List<MapFunction> mapFunctions)
    {
        this.mapFunctions = mapFunctions;
    }

    public List<Range> Transform(List<Range> ranges)
    {
        List<Range> unMappedRanges = ranges;
        List<Range> mappedRanges = new List<Range>();
        foreach (MapFunction mapFunction in mapFunctions)
        {
            (unMappedRanges, List<Range> newMappedRanges) = MapRanges(unMappedRanges, mapFunction);
            mappedRanges.AddRange(newMappedRanges);
        }
        mappedRanges.AddRange(unMappedRanges);
        return mappedRanges;
    }

    private (List<Range>, List<Range>) MapRanges(List<Range> inputRanges, MapFunction mapFunction)
    {
        List<Range> unMappedRanges = new List<Range>();
        List<Range> mappedRanges = new List<Range>();
        foreach (Range range in inputRanges)
        {
            if (IsRangeWithinMapFunction(mapFunction, range))
            {
                Range mappedRange = MapRangeFullyWithinMapFunction(mapFunction, range);
                mappedRanges.Add(mappedRange);
            }
            else if (IsRangeOutsideMapFunction(mapFunction, range))
            {
                unMappedRanges.Add(range);
            }
            else
            {
                if (DoesRangeOverlapStartOfMapFunction(mapFunction, range))
                {
                    Range unMappedRange = new Range(range.Start, mapFunction.SourceStart - range.Start);
                    long mappedRangeEnd = long.Min(range.End, mapFunction.SourceEnd);
                    Range mappedRange = new Range(mapFunction.DestinationStart, mappedRangeEnd - mapFunction.SourceStart);
                    mappedRanges.Add(mappedRange);
                    unMappedRanges.Add(unMappedRange);
                }
                if (DoesRangeOverlapEndOfMapFunction(mapFunction, range))
                {
                    Range unMappedRange = new Range(mapFunction.SourceEnd, range.End - mapFunction.SourceEnd);
                    unMappedRanges.Add(unMappedRange);
                    if (mappedRanges.Count == 0)
                    {
                        Range mappedRange = MapRangeOverlappingEndOfMapFunction(mapFunction, range);
                        mappedRanges.Add(mappedRange);
                    }
                }
            }
        }
        return (unMappedRanges, mappedRanges);
    }

    private static Range MapRangeOverlappingEndOfMapFunction(MapFunction mapFunction, Range range)
    {
        long start = range.Start - mapFunction.SourceStart + mapFunction.DestinationStart;
        long length = mapFunction.SourceEnd - range.Start;
        Range mappedRange = new Range(start, length);
        return mappedRange;
    }

    private static bool DoesRangeOverlapEndOfMapFunction(MapFunction mapFunction, Range range)
    {
        return range.End > mapFunction.SourceEnd;
    }

    private static bool DoesRangeOverlapStartOfMapFunction(MapFunction mapFunction, Range range)
    {
        return range.Start < mapFunction.SourceStart;
    }

    private static Range MapRangeFullyWithinMapFunction(MapFunction mapFunction, Range range)
    {
        long start = range.Start - mapFunction.SourceStart + mapFunction.DestinationStart;
        Range mappedRange = new Range(start, range.Length);
        return mappedRange;
    }

    private static bool IsRangeOutsideMapFunction(MapFunction mapFunction, Range range)
    {
        return range.End < mapFunction.SourceStart || mapFunction.SourceEnd < range.Start;
    }

    private static bool IsRangeWithinMapFunction(MapFunction mapFunction, Range range)
    {
        return range.Start >= mapFunction.SourceStart && range.End <= mapFunction.SourceEnd;
    }

}
