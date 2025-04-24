namespace Codewars.DivideAndConquer;

public class ClosestPair
{
    public int FindClosestPair(int[] nums)
    {
        return Closest_Pair(nums, 0, nums.Length - 1);
    }

    public int Closest_Pair(int[] nums, int left, int right)
    {
        if (right - left == 1)
        {
            return nums[right] - nums[left];
        }
        
        if (left == right)
        {
            return int.MaxValue;
        }
        int mid = (left + right) / 2;
        int leftMin = Closest_Pair(nums, left, mid);
        int rightMin = Closest_Pair(nums, mid + 1, right);
        int minOfBoth = Math.Min(leftMin, rightMin);
        
        // Check if the closest pair crosses the dividing line
        // Only if there are points on both sides
 
        int crossMin = nums[mid + 1] - nums[mid];
       
        
        // Return the minimum of all three possibilities
        return Math.Min(minOfBoth, crossMin);
    }
}