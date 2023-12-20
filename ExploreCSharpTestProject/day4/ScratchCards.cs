namespace ExploreCSharpTestProject;

public class Card {
    public int Matches;

    public Card(int matches) {
        this.Matches = matches;
    }
}

public class ScratchCards {

    private string[] input;
    public ScratchCards(string[] input) {
        this.input = input;
    }

    public int CountTotal() {
        int sum = 0;
        foreach (string line in input) {
            sum += GetCardScore(line);
        }
        return sum;
    }

    public int CountAllCards() {
        Dictionary<int,List<Card>> cards = new Dictionary<int, List<Card>>();
        for (int i = 0; i < input.Length; i++) {
            cards[i] = new List<Card>();
            cards[i].Add(ParseCard(input[i]));
        }
        for (int i = 0; i < cards.Count; i++) {
            foreach(Card card in cards[i]) {
                for (int j = 0; j < card.Matches; j ++) {
                    int new_card_index = i + j + 1;
                    if (new_card_index < cards.Count) {
                        cards[new_card_index].Add(cards[new_card_index][0]);
                    }
                }
            }
        }
        int sumOfAllCards = 0;
        foreach(List<Card> cardsOfNumber in cards.Values) {
            sumOfAllCards += cardsOfNumber.Count;
        }
        return sumOfAllCards;
    }

    public Card ParseCard(string line) {
        (List<int> winning_numbers, List<int> actual_numbers) = ParseAllNumbers(line);
        int matches = 0;
        foreach (int number in actual_numbers)
        {
            if (winning_numbers.Contains(number))
            {
                matches += 1;
            }
        }
        return new Card(matches);
    }
    

    public int GetCardScore(string card)
    {
        (List<int> winning_numbers, List<int> actual_numbers) = ParseAllNumbers(card);
        int score = 0;
        foreach (int number in actual_numbers)
        {
            if (winning_numbers.Contains(number))
            {
                if (score == 0)
                {
                    score = 1;
                }
                else
                {
                    score *= 2;
                }
            }
        }
        return score;
    }

    private static (List<int>, List<int>) ParseAllNumbers(string card)
    {
        // Card 1: 41 48 83 86 17 | 83 86  6 31 17  9
        string[] all_parts = card.Split(": ");
        string[] number_parts = all_parts[1].Split(" | ");
        string winning_numbers_string = number_parts[0];
        string actual_numbers_string = number_parts[1];
        List<int> winning_numbers, actual_numbers;
        winning_numbers = ParseNumbers(winning_numbers_string);
        actual_numbers = ParseNumbers(actual_numbers_string);
        return (winning_numbers, actual_numbers);
    }

    private static List<int> ParseNumbers(string numbers_string)
    {
        List<int> numbers = new List<int>();
        foreach (string number in numbers_string.Split(" "))
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