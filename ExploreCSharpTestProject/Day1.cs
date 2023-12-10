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
        if (first_index == -1)
        {
            first_index = int.MaxValue;
        }
        int last_index = input.LastIndexOfAny(numbers);
        return (first_index, last_index);
    }

    public static (int, int, int, int) GetFirstAndLastWords(string input)
    {
        string[] numbers = new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        int first_index = int.MaxValue, last_index = -1, first_number = -1, last_number = -1;

        for (int i = 0; i < numbers.Length; i++)
        {
            int candidate_first_index = input.IndexOf(numbers[i]);
            if (candidate_first_index != -1)
            {
                if (candidate_first_index < first_index)
                {
                    first_index = candidate_first_index;
                    first_number = i;
                }
            }

            int candidate_last_index = input.LastIndexOf(numbers[i]);
            if (candidate_last_index > last_index)
            {
                last_index = candidate_last_index;
                last_number = i;
            }
        }
        return (first_index, last_index, first_number, last_number);
    }


    public static int GetValueOfDigitIndex(string input, int index)
    {
        return int.Parse(input.ElementAt(index).ToString());
    }


    public static int GetCalibrationValueSingleLine(string input)
    {
        (int first_index_digit, int last_index_digit) = GetFirstAndLastIndexDigits(input);
        (int first_index_word, int last_index_word, int first_number, int last_number) = GetFirstAndLastWords(input);

        if (last_index_digit == -1 && last_index_word == -1)
        {
            return 0;
        }

        if (first_index_digit < first_index_word)
        {
            first_number = GetValueOfDigitIndex(input, first_index_digit);
        }

        if (last_index_digit > last_index_word)
        {
            last_number = GetValueOfDigitIndex(input, last_index_digit);
        }

        int result = first_number * 10 + last_number;

        return result;
    }
}

public class Day1Test
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
        Assert.Equal(99 + 19
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