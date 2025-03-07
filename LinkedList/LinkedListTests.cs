using NUnit.Framework;

namespace Codewars.LinkedList;

[TestFixture]
public class LinkedListTests
{
    [Test]
    [Order(1)]
    public void SampleTest()
    {
        Assert.That(Node.Stringify(new Node(1, new Node(2, new Node(3)))), Is.EqualTo("1 -> 2 -> 3 -> null"));
        Assert.That(Node.Stringify(new Node(0, new Node(1, new Node(4, new Node(9, new Node(16)))))), Is.EqualTo("0 -> 1 -> 4 -> 9 -> 16 -> null"));
        Assert.That(Node.Stringify(null), Is.EqualTo("null"));
    }
    [Test, Description("tests for inserting a node before another node.")]
    [Order(2)]
    public void pushTests()
    {
        Assert.That(Node.Push(null, 1).Data, Is.EqualTo(1), "Should be able to create a new linked list with push().");
        Assert.That(Node.Push(null, 1).Next, Is.Null, "Should be able to create a new linked list with push().");
        Assert.That(Node.Push(new Node(1), 2).Data, Is.EqualTo(2), "Should be able to prepend a node to an existing node.");
        Assert.That(Node.Push(new Node(1), 2).Next.Data, Is.EqualTo(1), "Should be able to prepend a node to an existing node.");
    }
    
    [Test, Description("tests for building a linked list.")]
    [Order(3)]
    public void buildTests()
    {
        Assert.That(Node.BuildOneTwoThree().Data, Is.EqualTo(1), "First node should should have 1 as data.");
        Assert.That(Node.BuildOneTwoThree().Next.Data, Is.EqualTo(2), "Second node should should have 2 as data.");
        Assert.That(Node.BuildOneTwoThree().Next.Next.Data, Is.EqualTo(3), "Third node should should have 3 as data.");
        Assert.That(Node.BuildOneTwoThree().Next.Next.Next, Is.Null, "Third node should be the tail of the linked list");
    }
}