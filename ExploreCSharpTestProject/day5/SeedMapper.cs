using System;

namespace ExploreCSharpTestProject;

public class SeedMapper
{
    private string[] input;
    public SeedMapper(string[] input)
    {
        this.input = input;
    }

    public long GetLowestMappedSeedRangeStyle()
    {
        string[] seeds_parts = input[0].Split(": ");
        List<long> seed_range_pairs = ParseNumbers(seeds_parts[1]);
        List<Range> seed_ranges = new List<Range>();
        for (int i = 0; i < seed_range_pairs.Count; i += 2)
        {
            seed_ranges.Add(new Range(seed_range_pairs[i], seed_range_pairs[i + 1]));
        }
        List<MapFunction> mapFunctions = new List<MapFunction>();
        bool isMapActive = false;

        for (long i = 2; i < input.Length; i++)
        {
            if (input[i].Contains("map"))
            {
            }
            else if (input[i].Length == 0)
            {
                RangeTransformer rangeTransformer = new RangeTransformer(mapFunctions);
                seed_ranges = rangeTransformer.Transform(seed_ranges);
                mapFunctions.Clear();
                isMapActive = false;
            }
            else
            {
                List<long> mapFunctionNumbers = ParseNumbers(input[i]);
                MapFunction mapFunction = new MapFunction(mapFunctionNumbers[0], mapFunctionNumbers[1], mapFunctionNumbers[2]);
                mapFunctions.Add(mapFunction);
                isMapActive = true;
            }
        }

        if (isMapActive)
        {
            RangeTransformer rangeTransformer = new RangeTransformer(mapFunctions);
            seed_ranges = rangeTransformer.Transform(seed_ranges);
        }

        Range lowestRange = new Range(long.MaxValue, 0);
        foreach(Range range in seed_ranges)
        {
            if (range.Start < lowestRange.Start)
            {
                lowestRange = range;
            }
        }

        return lowestRange.Start;
    }

    public long GetLowestMappedSeedNormal()
    {
        string[] seeds_parts = input[0].Split(": ");
        List<long> seeds = ParseNumbers(seeds_parts[1]);
        return GetLowestMappedSeed(seeds);
    }

    private long GetLowestMappedSeed(List<long> seeds)
    {
        List<string> mapString = new List<string>();
        bool isMapActive = false;

        for (long i = 2; i < input.Length; i++)
        {
            if (input[i].Contains("map"))
            {
            }
            else if (input[i].Length == 0)
            {
                seeds = MapSeeds(seeds, mapString);
                mapString.Clear();
                isMapActive = false;
            }
            else
            {
                mapString.Add(input[i]);
                isMapActive = true;
            }
        }

        if (isMapActive)
        {
            seeds = MapSeeds(seeds, mapString);
        }

        return seeds.Min();
    }

    public List<long> MapSeeds(List<long> seeds, List<string> map_strings)
    {
        List<List<long>> mapFunctions = new List<List<long>>();
        List<long> mappedValues = new List<long>();
        foreach (string map in map_strings)
        {
            mapFunctions.Add(ParseNumbers(map));
        }
        foreach (long seed in seeds)
        {
            bool isMapped = false;
            foreach (List<long> map_function in mapFunctions)
            {
                long source_start = map_function[1];
                long range = map_function[2];
                if (seed >= source_start && seed <= source_start + range)
                {
                    long destination_start = map_function[0];
                    long mapped_value = seed - source_start + destination_start;
                    mappedValues.Add(mapped_value);
                    isMapped = true;
                    break;
                }
            }
            if (!isMapped)
            {
                mappedValues.Add(seed);
            }
        }
        return mappedValues;
    }

    public List<long> ParseNumbers(string input)
    {
        List<long> numbers = new List<long>();
        foreach (string number in input.Split(" "))
        {
            long number_value;
            if (long.TryParse(number, out number_value))
            {
                numbers.Add(number_value);
            }
        }
        return numbers;
    }
}