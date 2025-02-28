namespace Codewars.TheObservedPin;

public class ObservedPin
{
    private static readonly Dictionary<char, char[]> AdjacentDigits = new Dictionary<char, char[]>
    {
        {'1', new[] {'1', '2', '4'}},
        {'2', new[] {'1', '2', '3', '5'}},
        {'3', new[] {'2', '3', '6'}},
        {'4', new[] {'1', '4', '5', '7'}},
        {'5', new[] {'2', '4', '5', '6', '8'}},
        {'6', new[] {'3', '5', '6', '9'}},
        {'7', new[] {'4', '7', '8'}},
        {'8', new[] {'5', '7', '8', '9', '0'}},
        {'9', new[] {'6', '8', '9'}},
        {'0', new[] {'0', '8'}}
    };
    public static List<string> GetPINs(string observed)
    {
        if (string.IsNullOrEmpty(observed))
        {
            return new List<string>();
        }

        List<string> pins = new List<string> { "" };
        
        foreach (char digit in observed)
        {
            char[] possibleDigits = AdjacentDigits[digit];
            
            List<string> newPins = new List<string>();
            
            foreach (string pin in pins)
            {
                foreach (char possibleDigit in possibleDigits)
                {
                    newPins.Add(pin + possibleDigit);
                }
            }
            
            pins = newPins;
        }
        
        return pins;
    }
}