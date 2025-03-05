using System.Text;

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
}