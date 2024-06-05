public class CurrencyConverter
{
    bool CheckSalary(int salary)
    {
        return salary > 50_000;
    }

    public string CurrencyToWord(int number, string word)
    {
        bool isValid = CheckSalary(number);

        if (isValid)
        {
            return CurrencyToWord(number, word, number);
        }
        return $"{isValid}";
    }

    string CurrencyToWord(int number, string word, int originalNumber)
    {
        

        if (number / 1_000_000 != 0)
        {
            word = string.Concat(CurrencyToWord(number / 1_000_000, word, originalNumber), " million ");
            number %= 1_000_000;
        }

        if (number / 1_000 != 0)
        {            
            word = string.Concat(CurrencyToWord(number / 1_000, word, originalNumber), " thousand ");
            number %= 1_000;
        }

        if (number / 100 != 0)
        {
            word = string.Concat(CurrencyToWord(number / 100, word, originalNumber), " hundred ");
            number %= 100;
        }

        word = NumberToWord(number, word);

        return word;
    }

    string NumberToWord(int number, string words)
    {
        if (words != "") words += " ";

        var unitValues = new[]
        {
            "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve",
            "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"
        };
        var tensValues = new[]
            { "", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

        if (number >= 20)
        {
            words += tensValues[number / 10];
            if (number % 10 > 0) words += "-" + unitValues[number % 10];
        }
        else
            words += unitValues[number];

        return words;
    }
}
