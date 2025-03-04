namespace Codewars.RomanNumerals;

public class RomanNumerals
{
    static readonly List<KeyValuePair<int, string>> romanNumerals = new List<KeyValuePair<int, string>>
    {
        new KeyValuePair<int, string>(1000, "M"),
        new KeyValuePair<int, string>(900,  "CM"),
        new KeyValuePair<int, string>(500,  "D"),
        new KeyValuePair<int, string>(400,  "CD"),
        new KeyValuePair<int, string>(100,  "C"),
        new KeyValuePair<int, string>(90,   "XC"),
        new KeyValuePair<int, string>(50,   "L"),
        new KeyValuePair<int, string>(40,   "XL"),
        new KeyValuePair<int, string>(10,   "X"),
        new KeyValuePair<int, string>(9,    "IX"),
        new KeyValuePair<int, string>(5,    "V"),
        new KeyValuePair<int, string>(4,    "IV"),
        new KeyValuePair<int, string>(1,    "I")
    };
    public static string ToRoman(int number)
    {
        string result = string.Empty;
        foreach (var pair in romanNumerals)
        {
            while (number >= pair.Key)
            {
                result += pair.Value;
                number -= pair.Key;
            }
        }
        return result;
    }

    public static int FromRoman(string roman)
    {
        int index = 0, result = 0;
        foreach (var pair in romanNumerals)
        {
            while (index < roman.Length && roman.Substring(index).StartsWith(pair.Value))
            {
                result += pair.Key;
                index += pair.Value.Length;
            }
            if (index >= roman.Length)
                break;
        }
        return result;
    }
}