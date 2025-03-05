using NUnit.Framework;

namespace Codewars.LinkedList;

[TestFixture]
public class LinkedListTests
{
    [Test]
    public void SampleTest()
    {
        Assert.That(Node.Stringify(new Node(1, new Node(2, new Node(3)))), Is.EqualTo("1 -> 2 -> 3 -> null"));
        Assert.That(Node.Stringify(new Node(0, new Node(1, new Node(4, new Node(9, new Node(16)))))), Is.EqualTo("0 -> 1 -> 4 -> 9 -> 16 -> null"));
        Assert.That(Node.Stringify(null), Is.EqualTo("null"));
    }
}