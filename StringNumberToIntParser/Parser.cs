namespace Codewars.StringNumberToIntParser;

public class Parser
{
    public static int ParseInt(string s)
    {
        IDictionary<string, int> numberWords = new Dictionary<string, int>()
        {
            { "zero", 0 },
            { "one", 1 },
            { "two", 2 },
            { "three", 3 },
            { "four", 4 },
            { "five", 5 },
            { "six", 6 },
            { "seven", 7 },
            { "eight", 8 },
            { "nine", 9 },
            { "ten", 10 },
            { "eleven", 11 },
            { "twelve", 12 },
            { "thirteen", 13 },
            { "fourteen", 14 },
            { "fifteen", 15 },
            { "sixteen", 16 },
            { "seventeen", 17 },
            { "eighteen", 18 },
            { "nineteen", 19 },
            { "twenty", 20 },
            { "thirty", 30 },
            { "forty", 40 },
            { "fifty", 50 },
            { "sixty", 60 },
            { "seventy", 70 },
            { "eighty", 80 },
            { "ninety", 90 },
            { "hundred", 100 },
            { "thousand", 1000 },
            { "million", 1000000 }
        };
        
        string[] words = s.Replace("-", " ").Replace(" and ", " ").Split(' ', StringSplitOptions.RemoveEmptyEntries);
        
        int result = 0;
        int tempNumber = 0;
        
        foreach (var word in words)
        {
            if (word == "hundred")
            {
                tempNumber *= 100;
            }
            else if (word == "thousand")
            {
                tempNumber *= 1000;
                result += tempNumber;
                tempNumber = 0;
            }
            else if (word == "million")
            {
                tempNumber *= 1000000;
                result += tempNumber;
                tempNumber = 0;
            }
            else if (numberWords.ContainsKey(word))
            {
                tempNumber += numberWords[word];
            }
        }
        
        return result + tempNumber;
    }
}