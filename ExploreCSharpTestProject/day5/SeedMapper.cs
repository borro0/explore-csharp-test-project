namespace ExploreCSharpTestProject;

public record MapFunction(long DestinationStart, long SourceStart, long Range);

public record Range(long Start, long Length);

public class SeedMapper
{
    private string[] input;
    public SeedMapper(string[] input)
    {
        this.input = input;
    }

    static public List<Range> MapRange(Range range, List<MapFunction> map_functions)
    {
        return new List<Range> { range };
    }

    public long GetLowestMappedSeedRangeStyle()
    {
        string[] seeds_parts = input[0].Split(": ");
        List<long> seed_range_pairs = ParseNumbers(seeds_parts[1]);
        List<Range> seed_ranges = new List<Range>();
        for (long i = 0; i < seed_range_pairs.Count; i += 2)
        {

        }
        return 0;
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