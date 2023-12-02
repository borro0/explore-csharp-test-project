namespace ExploreCSharpTestProject;


public class Program
{
    public static int SumOfCalibrationValues(string input) {
        char[] numbers = new char[] {'9'};
        input.IndexOfAny(numbers)
        return 0;
    }
}

public class UnitTest1
{
    [Fact]
    public void TestEmptyInput()
    {
        string input = "";
        Assert.Equal(0, Program.SumOfCalibrationValues(input));
    }

    [Fact]
    public void TestSingleLine_SingleDigit()
    {
        string input = "9vxfg";
        Assert.Equal(99, Program.SumOfCalibrationValues(input));
    }
}