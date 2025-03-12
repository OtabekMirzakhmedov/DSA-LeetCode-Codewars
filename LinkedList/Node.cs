using System.Text;
using ArgumentOutOfRangeException = System.ArgumentOutOfRangeException;

namespace Codewars.LinkedList;

public class Node
{
    public int Data { get; private set; }
    public Node Next { get; private set; }

    public Node(int data, Node next = null)
    {
        Data = data;
        Next = next;
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
}