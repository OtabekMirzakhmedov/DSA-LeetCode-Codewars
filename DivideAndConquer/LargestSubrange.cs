namespace Codewars.DivideAndConquer;

public class LargestSubrange
{
    public int MaxSubArray(int[] nums)
    {
        if (nums == null || nums.Length == 0)
            return 0;
            
        return FindMaxSubarray(nums, 0, nums.Length - 1);
    }
    
    private int FindMaxSubarray(int[] nums, int left, int right)
    {
        if (left == right)
            return nums[left];
        
        int mid = left + (right - left) / 2;
        
        int leftMax = FindMaxSubarray(nums, left, mid);
        
        int rightMax = FindMaxSubarray(nums, mid + 1, right);
        
        int crossingMax = FindMaxCrossingSubarray(nums, left, mid, right);
        
        return Math.Max(Math.Max(leftMax, rightMax), crossingMax);
    }
    
    private int FindMaxCrossingSubarray(int[] nums, int left, int mid, int right)
    {
        int leftSum = LeftMidMaxRange(nums, left, mid);
        
        int rightSum = RightMidMaxRange(nums, mid + 1, right);
        
        return leftSum + rightSum;
    }
    
    private int LeftMidMaxRange(int[] nums, int left, int mid)
    {
        int sum = 0;
        int maxSum = 0;
        
        for (int i = mid; i >= left; i--)
        {
            sum += nums[i];
            if (sum > maxSum)
                maxSum = sum;
        }
        
        return maxSum;
    }
    
    private int RightMidMaxRange(int[] nums, int mid, int right)
    {
        int sum = 0;
        int maxSum = 0;
        
        for (int i = mid; i <= right; i++)
        {
            sum += nums[i];
            if (sum > maxSum)
                maxSum = sum;
        }
        
        return maxSum;
    }
}