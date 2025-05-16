namespace Codewars.PriorityQueue;

public class MaxSubsequence
{
    public int[] FindMaxSubsequence(int[] nums, int k) {
        var minHeap = new PriorityQueue<(int value, int index), int>();
        
        for (int i = 0; i < nums.Length; i++) {
            if (minHeap.Count < k) {
                minHeap.Enqueue((nums[i], i), nums[i]);
            }
            else if (nums[i] > minHeap.Peek().value) {
                minHeap.Dequeue();
                minHeap.Enqueue((nums[i], i), nums[i]);
            }
        }
        
        var selectedElements = new List<(int value, int index)>();
        while (minHeap.Count > 0) {
            selectedElements.Add(minHeap.Dequeue());
        }
        
        selectedElements.Sort((a, b) => a.index.CompareTo(b.index));
        
        int[] result = new int[k];
        for (int i = 0; i < k; i++) {
            result[i] = selectedElements[i].value;
        }
        
        return result;
    }
}