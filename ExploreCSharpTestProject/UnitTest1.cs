namespace ExploreCSharpTestProject;
using System.IO;
using Xunit.Sdk;
using System.Reflection;

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

    public static (int, int) GetFirstAndLastIndexDigits(string input)
    {
        char[] numbers = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        int first_index = input.IndexOfAny(numbers);
        int last_index = input.LastIndexOfAny(numbers);
        return (first_index, last_index);
    }

    public static (int, int) GetFirstAndLastIndexWords(string input)
    {
        string[] numbers = new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        int first_index = input.IndexOfAny(numbers);
        int last_index = input.LastIndexOfAny(numbers);
        return (first_index, last_index);
    }


    public static string GetStringValueOfDigitIndex(string input, int index)
    {
        return input.ElementAt(index).ToString();
    }


    public static int GetCalibrationValueSingleLine(string input)
    {
        (int first_index_digit, int last_index_digit) = GetFirstAndLastIndexDigits(input);
        (int first_index_word, int last_index_word) = GetFirstAndLastIndexWords(input);

        if (first_index_digit == -1 || last_index_digit == -1)
        {
            return 0;
        }

        string first_number = GetStringValueOfDigitIndex(input, first_index_digit);
        string last_number = GetStringValueOfDigitIndex(input, last_index_digit);
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
    public void TestSingleLine_WholeWords()
    {
        string input = "two1nine";
        Assert.Equal(29, Program.GetCalibrationValueSingleLine(input));
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
        string input_file_path = @"C:\Users\bblokland\explore-csharp-test-project\ExploreCSharpTestProject\advent-of-code-day-1-input.txt";
        string[] input = File.ReadAllLines(input_file_path);
        int result = Program.SumOfCalibrationValues(input);
        Console.WriteLine($"Result: {result}");
    }
}