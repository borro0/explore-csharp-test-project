namespace ExploreCSharpTestProject;

public struct Position
{
    public int CharIndex;
    public int LineIndex;

    public Position(int charIndex, int lineIndex)
    {
        CharIndex = charIndex;
        LineIndex = lineIndex;
    }
}

public class EngineNumbers
{
    private string[] input;
    public EngineNumbers(string[] string_input)
    {
        input = string_input;
    }

    public int CalculateNumber()
    {
        for (int lineIndex = 0; lineIndex < input.Length; lineIndex++)
        {
            lineLength = input[lineIndex].Length;
            for (int charIndex = 0; charIndex < lineLength; charIndex++)
            {
                ProcessCharacter(charIndex, lineIndex);
            }
        }
        return sum;
    }

    public int SumOfGearRatios()
    {
        for (int lineIndex = 0; lineIndex < input.Length; lineIndex++)
        {
            lineLength = input[lineIndex].Length;
            for (int charIndex = 0; charIndex < lineLength; charIndex++)
            {
                ProcessCharacter(charIndex, lineIndex);
            }
            ProcessNonDigit(); // to close of the current line
        }
        int sum = 0;
        foreach ((Position position, List<int> numbers) in GearMap) {
            if (numbers.Count == 2) {
                sum += numbers[0] * numbers[1];
            }
        }
        return sum;
    }

    private static readonly Position InvalidPosition = new Position(-1, -1);

    private int lineLength = 0;

    private bool numberActive = false;
    private bool isNumberWithSymbol = false;
    private int currentNumber = 0;
    private int sum = 0;
    private Position GearPosition = InvalidPosition;
    private Dictionary<Position, List<int>> GearMap = [];

    private void ProcessCharacter(int charIndex, int lineIndex)
    {
        char character = input[lineIndex][charIndex];
        if (Char.IsDigit(character))
        {
            ProcessDigit(charIndex, lineIndex, character);
        }
        else
        {
            ProcessNonDigit();
        }
    }

    private void ProcessNonDigit()
    {
        if (numberActive)
        {
            CloseNumber();
        }

    }

    private void CloseNumber()
    {
        if (isNumberWithSymbol)
        {
            sum += currentNumber;
        }
        if (!GearPosition.Equals(InvalidPosition))
        {
            if (!GearMap.ContainsKey(GearPosition))
            {
                GearMap[GearPosition] = new List<int>();
            }
            GearMap[GearPosition].Add(currentNumber);
            GearPosition = InvalidPosition;
        }
        numberActive = false;
        isNumberWithSymbol = false;
        currentNumber = 0;
    }

    private void ProcessDigit(int charIndex, int lineIndex, char character)
    {
        int value = int.Parse(character.ToString());
        if (numberActive)
        {
            currentNumber = currentNumber * 10 + value;
        }
        else
        {
            numberActive = true;
            currentNumber = value;
        }
        if (!isNumberWithSymbol)
        {
            isNumberWithSymbol = CheckForSymbolNeighbor(charIndex, lineIndex);
        }
        if (GearPosition.Equals(InvalidPosition))
        {
            GearPosition = CheckForGearSymbolNeighbor(charIndex, lineIndex);
        }
    }

    private bool CheckForSymbolNeighbor(int charIndex, int lineIndex)
    {
        List<Position> positionsToCheck = new List<Position>();
        for (int i = -1; i <= 1; i++)
        {
            positionsToCheck.Add(new Position(charIndex - 1, lineIndex + i));
            positionsToCheck.Add(new Position(charIndex, lineIndex + i));
            positionsToCheck.Add(new Position(charIndex + 1, lineIndex + i));
        }
        foreach (Position position in positionsToCheck)
        {
            if (IsPositionValid(position) && IsSymbolAtPosition(position))
            {
                return true;
            }
        }
        return false;
    }

    private Position CheckForGearSymbolNeighbor(int charIndex, int lineIndex)
    {
        List<Position> positionsToCheck = new List<Position>();
        for (int i = -1; i <= 1; i++)
        {
            positionsToCheck.Add(new Position(charIndex - 1, lineIndex + i));
            positionsToCheck.Add(new Position(charIndex, lineIndex + i));
            positionsToCheck.Add(new Position(charIndex + 1, lineIndex + i));
        }
        foreach (Position position in positionsToCheck)
        {
            if (IsPositionValid(position) && IsGearAtPosition(position))
            {
                return position;
            }
        }
        return InvalidPosition;
    }

    private bool IsPositionValid(Position position)
    {
        bool validCharIndex = position.CharIndex >= 0 && position.CharIndex < lineLength;
        bool validLineIndex = position.LineIndex >= 0 && position.LineIndex < input.Length;
        return validCharIndex && validLineIndex;
    }

    private bool IsGearAtPosition(Position position)
    {
        char charAtPosition = input[position.LineIndex][position.CharIndex];
        return charAtPosition == '*';
    }

    private bool IsSymbolAtPosition(Position position)
    {
        char nextChar = input[position.LineIndex][position.CharIndex];
        return IsSymbol(nextChar);
    }

    private static bool IsSymbol(char character)
    {
        if (Char.IsDigit(character))
        {
            return false;
        }
        if (character == '.')
        {
            return false;
        }
        return true;
    }
}