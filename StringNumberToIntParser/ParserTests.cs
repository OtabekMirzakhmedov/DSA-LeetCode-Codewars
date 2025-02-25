using NUnit.Framework;

namespace Codewars.StringNumberToIntParser;

public class ParserTests
{
    [Test]
    public void FixedTests()
    {
        Assert.That(Parser.ParseInt("one thousand three hundred thirty-seven"), Is.EqualTo(1337));
        Assert.That(Parser.ParseInt("two hundred forty-six"), Is.EqualTo(246));
        Assert.That(Parser.ParseInt("one"), Is.EqualTo(1));
        Assert.That(Parser.ParseInt("twenty"), Is.EqualTo(20));
        
    }
}