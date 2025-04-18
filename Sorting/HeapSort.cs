namespace Codewars.Sorting;

public class HeapSort
{
    public int[] MinSort(int[] nums)
    {
        var pq = new PriorityQueue(nums.Length);
        foreach (var x in nums)
            pq.Insert(x);

        var sorted = new int[nums.Length];
        for (int i = 0; i < sorted.Length; i++)
            sorted[i] = pq.ExtractMin();

        return sorted;

    }
    
    
}