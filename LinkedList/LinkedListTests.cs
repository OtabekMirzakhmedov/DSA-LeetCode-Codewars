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
    
    [Test, Description("tests for counting the length of a linked list.")]
    [Order(4)]
    public void LengthTest()
    {
        Node list = Node.BuildOneTwoThree();
        Assert.That(Node.Length(null), Is.EqualTo(0), "Length of null list should be zero.");
        Assert.That(Node.Length(new Node(99)), Is.EqualTo(1), "Length of single node list should be one.");
        Assert.That(Node.Length(list), Is.EqualTo(3), "Length of the three node list should be three.");
    }
    
    [Test, Description("tests for counting occurences of data that satisfies a condition.")]
    [Order(5)]
    public void CountTest()
    {
        Node list = Node.BuildOneTwoThree();
        Assert.That(Node.Count(list, value => value == 1), Is.EqualTo(1), "list should only contain one 1.");
        Assert.That(Node.Count(list, value => value == 2), Is.EqualTo(1), "list should only contain one 2.");
        Assert.That(Node.Count(list, value => value == 3), Is.EqualTo(1), "list should only contain one 3.");
        Assert.That(Node.Count(list, value => value == 99), Is.EqualTo(0), "list should return zero for integer not found in list.");
        Assert.That(Node.Count(null, value => value == 1), Is.EqualTo(0), "null list should always return count of zero.");
      
        Assert.That(Node.Count(list, value => value % 2 != 0), Is.EqualTo(2), "list should contain two odd numbers.");
        Assert.That(Node.Count(list, value => value % 2 == 0), Is.EqualTo(1), "list should contain one even number.");
    }
    
    [Test, Description("tests for getting the Nth node in a linked list.")]
    [Order(5)] 
    public void GetNthTest()
    {
        Node list = Node.BuildOneTwoThree();
      
        Assert.That(Node.GetNth(list, 0).Data, Is.EqualTo(1), "First node should be located at index 0.");
        Assert.That(Node.GetNth(list, 1).Data, Is.EqualTo(2), "Second node should be located at index 1.");
        Assert.That(Node.GetNth(list, 2).Data, Is.EqualTo(3), "Third node should be located at index 2.");
        Assert.Throws<ArgumentException>(() => Node.GetNth(list, 3), "Invalid index value should throw an exception.");
        Assert.Throws<ArgumentException>(() => Node.GetNth(list, 100), "Invalid index value should throw an exception.");
        Assert.Throws<ArgumentException>(() => Node.GetNth(null, 0), "Null linked list should throw an exception.");
    }
    
    [Test, Description("should be able to handle an empty list."), Order(6)]
    public void EmptyTest()
    {
      Assert.That(Node.InsertNth(null, 0, 12).Data, Is.EqualTo(12), "should be able to insert a node on an empty/null list.");
      Assert.That(Node.InsertNth(null, 0, 12).Next, Is.Null, "value at index 1 should be null.");
    }
    
    [Test, Description("should be able to insert a new node at the head of a list."), Order(7)]
    public void TestIndex0()
    {
      var expectedData = 23;
      Assert.That(Node.InsertNth(Node.BuildOneTwoThree(), 0, 23).Data, Is.EqualTo(expectedData), "should be able to insert new node at head of list.");
      Assert.That(Node.InsertNth(Node.BuildOneTwoThree(), 0, 23).Next.Data, Is.EqualTo(1), "value for node at index 1 should be 1.");
      Assert.That(Node.InsertNth(Node.BuildOneTwoThree(), 0, 23).Next.Next.Data, Is.EqualTo(2), "value for node at index 2 should be 2.");
      Assert.That(Node.InsertNth(Node.BuildOneTwoThree(), 0, 23).Next.Next.Next.Data, Is.EqualTo(3), "value for node at index 3 should be 3.");
      Assert.That(Node.InsertNth(Node.BuildOneTwoThree(), 0, 23).Next.Next.Next.Next, Is.Null, "value at index 4 should be null.");
    }
    
    [Test, Description("should be able to insert a new node at index 1 of a list."), Order(8)]
    public void TestIndex1()
    {
      Assert.That(Node.InsertNth(Node.BuildOneTwoThree(), 1, 23).Data, Is.EqualTo(1), "value for node at index 0 should remain unchanged.");
      Assert.That(Node.InsertNth(Node.BuildOneTwoThree(), 1, 23).Next.Data, Is.EqualTo(23), "value for node at index 1 should be 23.");
      Assert.That(Node.InsertNth(Node.BuildOneTwoThree(), 1, 23).Next.Next.Data, Is.EqualTo(2), "value for node at index 2 should be 2.");
      Assert.That(Node.InsertNth(Node.BuildOneTwoThree(), 1, 23).Next.Next.Next.Data, Is.EqualTo(3), "value for node at index 3 should be 3.");
      Assert.That(Node.InsertNth(Node.BuildOneTwoThree(), 1, 23).Next.Next.Next.Next, Is.Null, "value at index 4 should be null.");
    }
    
    [Test, Description("should be able to insert a new node at index 2 of a list."), Order(9)]
    public void TestIndex2()
    {
      Assert.That(Node.InsertNth(Node.BuildOneTwoThree(), 2, 23).Data, Is.EqualTo(1), "value for node at index 0 should remain unchanged.");
      Assert.That(Node.InsertNth(Node.BuildOneTwoThree(), 2, 23).Next.Data, Is.EqualTo(2), "value for node at index 1 should remain unchanged.");
      Assert.That(Node.InsertNth(Node.BuildOneTwoThree(), 2, 23).Next.Next.Data, Is.EqualTo(23), "value for node at index 2 should be 23.");
      Assert.That(Node.InsertNth(Node.BuildOneTwoThree(), 2, 23).Next.Next.Next.Data, Is.EqualTo(3), "value for node at index 3 should be 3.");
      Assert.That(Node.InsertNth(Node.BuildOneTwoThree(), 2, 23).Next.Next.Next.Next, Is.Null, "value at index 4 should be null.");
    }
    
    [Test, Description("should be able to insert a new node at the tail of a list."), Order(10)]
    public void TestIndex3()
    {
      Assert.That(Node.InsertNth(Node.BuildOneTwoThree(), 3, 23).Data, Is.EqualTo(1), "head should remain unchanged after inserting new node at tail");
      Assert.That(Node.InsertNth(Node.BuildOneTwoThree(), 3, 23).Next.Data, Is.EqualTo(2), "value at index 1 should remain unchanged after inserting new node at tail");
      Assert.That(Node.InsertNth(Node.BuildOneTwoThree(), 3, 23).Next.Next.Data, Is.EqualTo(3), "value at index 2 should remain unchanged after inserting new node at tail");
      Assert.That(Node.InsertNth(Node.BuildOneTwoThree(), 3, 23).Next.Next.Next.Data, Is.EqualTo(23), "value for node at index 3 should be 23.");
      Assert.That(Node.InsertNth(Node.BuildOneTwoThree(), 3, 23).Next.Next.Next.Next, Is.Null, "value at index 4 should be null.");
    }
    
    [Test, Description("should throw ArgumentOutOfRangeException if index is out of range"), Order(11)]
    public void ExceptionTest()
    {
      Assert.Throws<ArgumentOutOfRangeException>(() => Node.InsertNth(Node.BuildOneTwoThree(), 4, 23), "Invalid index value should throw ArugmentException");
      Assert.Throws<ArgumentOutOfRangeException>(() => Node.InsertNth(Node.BuildOneTwoThree(), -4, 23), "Invalid index value should throw ArugmentException");
    }
}