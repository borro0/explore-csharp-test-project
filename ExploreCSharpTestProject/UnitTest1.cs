namespace ExploreCSharpTestProject;
using System.IO;
using Xunit.Sdk;

public class Program
{
    public static int SumOfCalibrationValues(string[] input)
    {
        int result = 0;
        foreach (string line in input)
        {
            result += GetCalibrationValueSingleLine(line);
        }
        return result;
    }


    public static int GetCalibrationValueSingleLine(string input)
    {
        char[] numbers = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        int first_index = input.IndexOfAny(numbers);

        if (first_index == -1)
            return 0;

        int last_index = input.LastIndexOfAny(numbers);
        string first_number = input.ElementAt(first_index).ToString();
        string last_number = input.ElementAt(last_index).ToString();
        string result_string = first_number + last_number;
        int result = int.Parse(result_string);

        return result;
    }
}

public class UnitTest1
{
    [Fact]
    public void TestEmptyInput()
    {
        string input = "";
        Assert.Equal(0, Program.GetCalibrationValueSingleLine(input));
    }

    [Fact]
    public void TestSingleLine_SingleDigit()
    {
        string input = "9vxfg";
        Assert.Equal(99, Program.GetCalibrationValueSingleLine(input));
    }

    [Fact]
    public void TestMultipleLines()
    {
        string[] input = { "9vxfg", "19qdlpmdrxone7sevennine" };
        Assert.Equal(99 + 17
        , Program.SumOfCalibrationValues(input));
    }

    [Fact]
    public void TestCompleteSolution()
    {
        string[] input = File.ReadAllLines(@"ExploreCSharpTestProject\advent-of-code-day-1-input.txt");
        int result = Program.SumOfCalibrationValues(input);
        Console.WriteLine($"Result: {result}");
    }
}