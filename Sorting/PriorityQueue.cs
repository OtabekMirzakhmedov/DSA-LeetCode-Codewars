namespace Codewars.Sorting;

public class PriorityQueue
{
    private int[] q;
    private int n;

    public PriorityQueue(int capacity)
    {
        q = new int[capacity+1];
        n = 0;
    }
    
    private int Parent(int k) => k == 1 ? -1 : k / 2;
    private int Left(int k)  => 2 * k;
    private int Right(int k) => 2 * k + 1;

    private void Swap(int i, int j) => (q[i], q[j]) = (q[j], q[i]);
    
    public void Insert(int x)
    {
        if (n + 1 >= q.Length)
            throw new InvalidOperationException("Heap overflow");
        q[++n] = x;
        BubbleUp(n);
    }

    private void BubbleUp(int k)
    {
        while (Parent(k) != -1 && q[Parent(k)] > q[k])
        {
            int p = Parent(k);
            Swap(p, k);
            k = p;
        }
    }
    
    public int ExtractMin()
    {
        if (n == 0)
            throw new InvalidOperationException("Heap is empty");
        int min = q[1];
        q[1] = q[n--];
        SiftDown(1);
        return min;
    }

    private void SiftDown(int k)
    {
        while (true)
        {
            int l = Left(k), r = Right(k), smallest = k;
            if (l <= n && q[l] < q[smallest]) smallest = l;
            if (r <= n && q[r] < q[smallest]) smallest = r;
            if (smallest == k) break;
            Swap(k, smallest);
            k = smallest;
        }
    }

    public int Count => n;
}