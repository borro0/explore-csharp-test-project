namespace ExploreCSharpTestProject;

public class SeedMapper
{
    private string[] input;
    public SeedMapper(string[] input)
    {
        this.input = input;
    }

    public int GetLowestMappedSeed()
    {
        string[] seeds_parts = input[0].Split(": ");
        List<int> seeds = ParseNumbers(seeds_parts[1]);
    }

    public List<int> ParseNumbers(string input)
    {
        List<int> numbers = new List<int>();
        foreach (string number in input.Split(" "))
        {
            int number_value;
            if (int.TryParse(number, out number_value))
            {
                numbers.Add(number_value);
            }
        }
        return numbers;
    }
}