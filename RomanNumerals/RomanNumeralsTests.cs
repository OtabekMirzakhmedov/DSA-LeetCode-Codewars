using NUnit.Framework;

namespace Codewars.RomanNumerals;

[TestFixture]
public class RomanNumeralsTests
{
    [Test, Order(1)]
    public void TestToRoman_001()
    {
        int input = 1;
        string expected = "I";

        string actual = RomanNumerals.ToRoman(input);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test, Order(2)]
    public void TestToRoman_002()
    {
        int input = 2;
        string expected = "II";

        string actual = RomanNumerals.ToRoman(input);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test, Order(3)]
    public void TestFromRoman_001()
    {
        string input = "I";
        int expected = 1;

        int actual = RomanNumerals.FromRoman(input);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test, Order(4)]
    public void TestFromRoman_002()
    {
        string input = "II";
        int expected = 2;

        int actual = RomanNumerals.FromRoman(input);

        Assert.That(actual, Is.EqualTo(expected));
    }
}