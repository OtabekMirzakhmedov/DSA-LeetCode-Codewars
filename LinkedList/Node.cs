using System.Text;
using ArgumentOutOfRangeException = System.ArgumentOutOfRangeException;

namespace Codewars.LinkedList;

public class Node : Object
{
    public int Data { get; private set; }
    public Node Next { get; private set; }

    public Node(int data, Node next = null)
    {
        Data = data;
        Next = next;
    }
    
    public override bool Equals(Object obj)
    {
        // Check for null values and compare run-time types.
        if (obj == null || GetType() != obj.GetType()) { return false; }
  
        return this.ToString() == obj.ToString();
    }
    
    public override string ToString()
    {
        List<int> result = new List<int>();
        Node curr = this;
    
        while (curr != null)
        {
            result.Add(curr.Data);
            curr = curr.Next;
        }
    
        return String.Join(" -> ", result) + " -> null";
    }

    public static string Stringify(Node? list)
    {
        StringBuilder result = new StringBuilder("");

        while (list != null)
        {
            result.Append(list.Data.ToString());
            result.Append(" -> ");
            list = list.Next;
        }

        result.Append("null");

        return result.ToString();
    }

    public static Node Push(Node? head, int data)
    {
        Node newNode = new Node(data);
        newNode.Next = head;
        return newNode;
    }

    public static Node BuildOneTwoThree()
    {
        Node? result = null;

        result = Push(result, 3);
        result = Push(result, 2);
        result = Push(result, 1);

        return result;
    }

    public static int Length(Node? head)
    {
        int length = 0;
        while (head != null)
        {
            length += 1;
            head = head.Next;
        }

        return length;
    }

    public static int Count(Node? head, Predicate<int> func)
    {
        int count = 0;
        while (head != null)
        {
            if (func(head.Data))
            {
                count += 1;
            }

            head = head.Next;
        }

        return count;
    }

    public static Node GetNth(Node node, int index)
    {
        int indexCount = 0;
        while (node != null && indexCount <= index)
        {
            if (indexCount == index)
            {
                return node;
            }

            indexCount++;
            node = node.Next;
        }

        throw new ArgumentException();
    }

    public static Node InsertNth(Node head, int index, int data)
    {
        Node insertingNode = new Node(data);
        
        if (index == 0)
        {
            insertingNode.Next = head;
            return insertingNode;
        }
        
        if (index < 0)
        {
            throw new ArgumentOutOfRangeException();
        }
        
        Node currentNode = head;
        
        for (int i = 0; i < index-1; i++)
        {
            if (currentNode == null)
            {
                throw new ArgumentOutOfRangeException();
            }

            currentNode = currentNode.Next;
        }
        
        if (currentNode == null)
        {
            throw new ArgumentOutOfRangeException();
        }
        
        insertingNode.Next = currentNode.Next;
        currentNode.Next = insertingNode;

        return head;
    }
    
    public static Node? Parse(string nodes)
    {
        if (nodes == "null")
        {
            return null;
        }
        var nodeList = nodes.Split(" -> ");
        return ParseHelper(nodeList);
    }

    public static Node? ParseHelper(string[] nodes)
    {
        if (nodes[0] == "null")
            return null;
    
        Node current = new Node(int.Parse(nodes[0]));
        current.Next = nodes.Length > 1 ? ParseHelper(nodes[1..]) : null;
        return current;
    }
}